# ParcelTracker-WebAPI

WebAPI частина проєкту

## Основні HTTP методи:

<p><span style="background-color: lightblue;">GET</span> /QuotaInfo/GetModel</p>
<p>**Отримує:** -<br>
**Віддає:** QuotaInfoModel<br>
**Опис:** віддає модель, що містить дані про квоту сервісу 17Track (квота - обмеження по реєстрації відправлень в системі)</p>

<p><span style="background-color: lightblue;">GET</span> /TrackingDetails</p>
<p>**Отримує:** ParcelCode (string)<br>
**Віддає:** TrackingDetailsModel<br>
**Опис:** повертає модель з усіма доступними даними щодо відслідковування відправлення для конкретного номера відправлення</p>

<p><span style="background-color: lightblue;">GET</span> /MyParcelsList</p>
<p>**Отримує:** user_id (int32)<br>
**Віддає:** List &lt;DatabaseModel&gt;<br>
**Опис:** віддає список моделей збережених відправлень для конкретного користувача</p>

<p><span style="background-color: lightgreen;">POST</span> /ParcelRegister</p>
<p>**Отримує:** user_id (int32), parcel_code (string), parcel_tag (string), parcel_description (string)<br>
**Віддає:** int32 (200 або код помилки)<br>
**Опис:** реєструє відправлення в реєстрі 17Track, якщо успішно то додає до БД та віддає код 200 (якщо помилка - код помилки)</p>

<p><span style="background-color: lightcoral;">DELETE</span> /ParcelDelete</p>
<p>**Отримує:** parcel_code (string)<br>
**Віддає:** int32 (200 або код помилки)<br>
**Опис:** видаляє відправлення з реєстру 17Track, якщо успішно то видаляє з БД та віддає код 200 (якщо помилка - код помилки)</p>
