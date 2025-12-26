cd ../../jumpstart/src
make
cd -
make
cd server/api
make
cd -
cd server/agent
make
cd server/sceduler
make
cd -
cd test/test-persist
make
cd -
cd test/test-api
make
cd -
cd test/test-script
make
cd -
cd test/test-agent
make
cd -
cd test/test-scheduler
make
cd -
cd web
dotnet build
