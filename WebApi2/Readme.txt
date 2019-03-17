Краткое пояснение по задаче:

1. В качестве технологии БД используется EF. Скрипт создания БД в файле TestApiModel.edmx.sql(проект WebApi2_DAL);
2. Строка подключения к БД находится в 2 местах: app.config и web.config;
3. Для сохранения данных на сервере выполнить запрос:

POST http://localhost:57061/api/test/SaveTestValues HTTP/1.1
Host: localhost:57061
Accept: application/json, text/javascript,*/*;q=0.8
Accept-Language: ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3
Content-Type: application/json

{
"7": "value12",
"1": "value1",
"5": "value2"
}

4. Для получения данных на сервере выполнить запрос:

GET http://localhost:57061/api/test/GetTestValues?code=2&value=Two HTTP/1.1
Host: localhost:57061
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8