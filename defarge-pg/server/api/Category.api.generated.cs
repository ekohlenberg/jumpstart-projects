
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<CategoryView> categorys = CategoryLogic.Create().select<CategoryView>();

            return categorys;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(long id)
        {
            //Console.WriteLine($"Processing Category GET ID={id}");

            Category category = CategoryLogic.Create().get(id);

            return category;
        }

        // GET api/<CategoryController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Category> categorys = CategoryLogic.Create().select<Category>();

            return categorys.Select(category => new EnumHelper(category.id, category.getRwkString()));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public CategoryView Post([FromBody] CategoryView categoryView)
        {
            //Console.WriteLine($"Processing Category POST: {category}");
            
            JsonHelper.ProcessJsonElements(categoryView);
            
            // Process any JsonElement values to ensure proper type conversion
            Category category = new Category(categoryView);

            
            
            CategoryLogic.Create().put(category); 

            categoryView.id = category.id;

            return categoryView;
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public CategoryView Put(long id, [FromBody] CategoryView categoryView)
        {
            //Console.WriteLine($"Processing Category PUT: ID = {id}\n{category}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(categoryView);
            
            Category category = new Category(categoryView);

            CategoryLogic.Create().update(id, category);

            categoryView.id = category.id;

            return categoryView;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            CategoryLogic.Create().delete(id);
        }

        // GET api/<CategoryController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<CategoryHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<CategoryHistory> historyList = CategoryLogic.Create().history(id);

            return historyList;
        }


        // GET api/<CategoryController>/5/category_parent
        [HttpGet("{id}/category_parent")]
        public IEnumerable<CategoryView> Getcategory_parent(long id)
        {
            //Console.WriteLine($"Processing GET Parent Category for Category ID={id}");

            List<CategoryView> categorys = CategoryLogic.Create().children<CategoryView>(id, "category-parent");

            return categorys;
        }

            
        
    }
}
