echo off
set url=https://localhost:5000

CALL:curl_test "Dane samochodu o ID 1" GET /car/1

CALL:curl_test "Wszystkie samochody" GET /car/all

CALL:curl_test "Dane samochodow klienta o ID 6" GET /car/all/client/6


echo Nazwa testu: "Dodaj samochod""
echo Testowany url: %url%%~3
curl -X POST https://localhost:5000/car/add -H "Content-Type: application/json" -d ^
"{^
	\"Make\": \"Renault\",^
	\"Model\": \"Megan\",^
	\"Year\": 2020,^
	\"Mileage\": 20000,^
	\"EngineSize\": \"3.5\",^
	\"VIN\": \"YV4A22RK1M1234567\",^
	\"LicensePlate\": \"PY21ZSL\",^
	\"ClientID\": 6^
}"
echo:
echo:

CALL:curl_test "Dane samochodu o ID 11" GET /car/11

EXIT /B 0

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X %~2 ^
	 %url%%~3 ^
	 -H 'accept:application/json'
echo:
echo:
EXIT /B 0