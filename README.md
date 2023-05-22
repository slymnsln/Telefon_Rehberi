# Telefon_Rehberi
Telefon Rehberi Uygulaması

# Kullanılan Teknolojiler
- NET Core
- Git
- PostgreSQL
- Rabbit Message Queue sistemi

# Nasıl Çalışır
- Öncelikle PostgreSQL veritbanı programını yükleyiniz.
- WebAPI katmanındaki appsettings.json dosyasını açıp. Alttaki resimde bulunan PgAdminContext connection ve RabbitMQService alanları düzenlenir.
- PgAdminContext connection bilgisi bilgisayarınızdaki kurulu olan postreSQL bilgileri girilebilir.
- RabbitMQService bilgisiyse RabbitMQ sunucunuz varsa bilgilerini girebilirsiniz kurulu değilse de şuanki yazan bilgi cloud RabbitMQ bağlıdır çalışacaktır.

![image](https://github.com/slymnsln/Telefon_Rehberi/assets/42764328/a0fcd3dd-54bc-4979-81b5-5ad3aba065bc)


- Migration işlemlerine başlanır. Package Manager Console açılarak.
- Add-Migration Init komutu çalıştırılır. "Build succeeded" mesajı alındıysa başarıyla tamamlanmıştır.
- Update-Database komutu çalıştırılır. "Build succeeded" mesajı alındıysa başarıyla tamamlanmıştır.
![image](https://github.com/slymnsln/Telefon_Rehberi/assets/42764328/2960fa56-4fbb-4861-98b8-db8ea65fda1f)


- Solution 'Telefon_Rehberi' ana solution'a sağ tıklanarak Properties açılır. Bu pencerede "Startup Project" olarak Telefon_Rehberi.WebAPI ve Telefon_Rehberi.WebApp' in Actiondan Start olarak seçilir.
![image](https://github.com/slymnsln/Telefon_Rehberi/assets/42764328/1bb09320-9a40-4e08-a0b8-fd9941ddfb05)

- Artık projemizi çalıştırabiliriz.
