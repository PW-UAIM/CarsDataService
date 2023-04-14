echo off
set url=https://localhost:5000

CALL:curl_test "Dane samochodu o ID 1" GET /car/1 

CALL:curl_test "Dane samochodow klienta o ID 6" GET /car/all/client/6


echo Nazwa testu: "Dodaj samochod o ID 20""
echo Testowany url: %url%%~3
curl -X POST https://localhost:5000/car/add -H "Content-Type: application/json"  -d ^
"{^
	\"carID\": 20,^
	\"make\": \"Renault\",^
	\"model\": \"Megan\",^
	\"year\": 2020,^
	\"mileage\": 20000,^
	 \"engineSize\": \"3.5\",^
	 \"VIN\": \"YV4A22RK1M1234567\",^
	 \"licensePlate\": \"PY21ZSL\",^
	 \"clientID\": 6^
}"
echo:
echo:

CALL:curl_test "Dane wizyty o ID 20" GET /car/20 

CALL:curl_test "Dane samochodow klienta o ID 6" GET /car/all/client/6

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X %~2 ^
	 %url%%~3 ^
	 -H 'accept:application/json'
echo:
echo:
pause