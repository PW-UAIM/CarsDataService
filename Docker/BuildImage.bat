docker login -u majumi -p uaimrzadzi

docker rmi majumi/carsdataservice:dataservice

docker build -f ../majumi.CarService.CarsDataService.Rest/Dockerfile.prod -t majumi/carsdataservice:dataservice ..

docker logout

pause