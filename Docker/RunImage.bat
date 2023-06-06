docker login -u majumi -p uaimrzadzi

docker stop carsdataservice

docker pull majumi/carsdataservice:dataservice

docker run --name carsdataservice -p 5001:5001 -it majumi/carsdataservice:dataservice

pause

docker stop carsdataservice

docker rm carsdataservice

pause