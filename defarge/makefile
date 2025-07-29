TARGETDIR=./bin/Debug/net9.0

default: build

build:
	@jumpstart ./defarge.csv database-mssql
	@jumpstart ./defarge.csv server-dotnet
	@jumpstart ./defarge.csv web-blazor

database:
	@jumpstart ./defarge.csv database-mssql

server:
	@jumpstart ./defarge.csv server-dotnet

web:
	@jumpstart ./defarge.csv web-blazor

clean:
	@rm -rf ./server
	@rm -rf ./database
	@rm -rf ./web

cleanuser:
	@rm -rf server/domain/*user*
	@rm -rf server/logic/*user*
	@rm -rf server/test/*user*

cleangen:
	@rm -rf server/domain/*generated*
	@rm -rf server/logic/*generated*
	@rm -rf server/test/*generated*
