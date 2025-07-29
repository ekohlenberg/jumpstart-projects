using System;
using Microsoft.AspNetCore.Mvc;
using RazorLight;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.Threading.Tasks;


namespace legr3
{
	public class ScriptHost 
	{

		private readonly RazorLightEngine razorEngine;

		public ScriptHost()
		{
			razorEngine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(BaseObject))
                .SetOperatingAssembly(typeof(BaseObject).Assembly)
                .UseMemoryCachingProvider()
                .Build();
		}

		public async void Invoke<T>(T model, BaseObject s) 
		{
			if (s.ContainsKey("source"))
			{
				string source = s["source"].ToString();
				string name = s["name"].ToString();

				await ExecCode<T>(model, name, "@{ try {" + source + "} catch( Exception e) {Model.EventException = e;}}");
			}

		}

		protected async Task ExecCode<T>(T model, string name, string script) 
        {
            if (model == null)
            {
                throw new Exception("Model cannot be null.");
            }

 			if (string.IsNullOrEmpty(name))
            {
                throw new Exception($"Script name cannot be null or empty.");
            }
            if (string.IsNullOrEmpty(script))
            {
                throw new Exception($"Script content cannot be null or empty.");
            }
            Logger.Debug( "Executing the script >>" + script + "<<");
            string generatedCode = await razorEngine.CompileRenderStringAsync<T>(name, script, model );

        }

	}

}