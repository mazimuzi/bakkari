# bakkari Dokumentaatio 

Viestintä backend, jolla voi lähettää viestejä joko tietylle käyttäjälle tai kaikille.
Käyttäjät autentikoidaan ja salasana tallennetaan turvallisessa muodossa.
Pyynnöt vaativat API avaimen.

<br>

# Esivaatimukset:

 •	.NET 8 SDK

 •	SQL Server (tai SQL Server Express)

 •	Visual Studio tai muu C# IDE

<br> 

# API:

Swagger UI saatavilla osoitteessa https://localhost:****/swagger/v1/swagger.json portti vaihtelee käyttöympäristön mukaan.

<br>

Viestit:

 • GET /api/Messages: Hakee kaikki viestit.

 •	GET /api/Messages/{id}: Hakee tietyn viestin ID:n perusteella.

 •	POST /api/Messages: Luo uuden viestin.

 •	PUT /api/Messages/{id}: Päivittää olemassa olevan viestin.

 •	DELETE /api/Messages/{id}: Poistaa viestin.

<br>

Käyttäjät:

 •	POST /api/users: Luo uuden käyttäjän.

 •	GET /api/users/{username}: Hakee tietyn käyttäjän käyttäjänimen perusteella.

 •	DELETE /api/users/{username}: Poistaa käyttäjän.

 <br>

# Projektin Rakenne:

 Controllers

  •	MessagesController.cs: Käsittelee HTTP-pyynnöt, jotka liittyvät viesteihin.

  •	UsersController.cs: Käsittelee HTTP-pyynnöt, jotka liittyvät käyttäjiin.

  <br>

 Services

  •	IMessageService.cs ja MessageService.cs: Liiketoimintalogiikka viestien käsittelyyn.

  •	IUserService.cs ja UserService.cs: Liiketoimintalogiikka käyttäjien käsittelyyn.

  •	IUserAuthenticationService.cs ja UserAuthenticationService.cs: Käsittelee käyttäjien autentikointia ja valtuutusta.

  <br>

 Repositories

  •	IMessageRepository.cs ja MessageRepository.cs: Tietojen käsittely viesteille.

  •	IUserRepository.cs ja UserRepository.cs: Tietojen käsittely käyttäjille.

  <br>

 Middleware

  •	ApiKeyMiddleware.cs: Middleware API-avaimen validointiin.

  <br>

 Models

  •	Message.cs: Tietomallit viesteille.

  •	User.cs: Tietomallit käyttäjille.
  
  •	MessageServiceContext.cs: Konteksti tietokannan hallintaan.
  <br>
