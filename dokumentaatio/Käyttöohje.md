# Käyttöohje

# Ohjelman lataaminen koneelle

Ohjelma on tehty C# .NET6 versiolla. Ohjeet C# .NET6 asentamiseen löytyy [tästä](https://dotnet.microsoft.com/en-us/download). C sharppia voi käyttää VS Codessa C# laajennuksella mutta suosittelen käyttämään Visual Studio 2022.

Kloona repositio koneellesi
```
git clone git@github.com:Zatyri/RSA.git
```

### Visual Studio 2022
Jos käytät Visual Studio 2022 voit avata tiedoston './RSA/RSA console app/RSA console app.sln'

Valitse "Build" valikosta "Build solution" tai paina pikanäppäintä F6.

Nyt voit käynnistää ohjelman painamalla vihreätä play nappia jonka vieressä lukee "RSA console app". Ohjelma aukeaa konsoliin ja ottaa syötteitä vastaan.

Testit ajat parheiten "Test Explorer" ikkunan kautta. Test Exporer ikkunan saat auki valikosta "Test" ja valitsemalla "Test Exporer" tai käyttämällä pikakomentoa "Ctrl+E,T". Test Explorer ikkunassa on oma vihreä play nappi joka käynnistää testit.

### Visual Studio Code + C# extension
Minulla ei ole tästä paljonkaan kokemusta. [Tästä](https://code.visualstudio.com/docs/languages/csharp) löydät viralliset ohjeet.

# RSA console app käyttöohje
## Komennot
### keys
Luo salaisen ja julkisen avainparin ja tallentaa ne tiedostoihin key.pub (julkinen avain) ja key.priv (salainen avain) haluttuun paikkaan. Ohjelma kysyy polkua mihin avaimet tallennetaan. Ohjelma kysyy myös avainten kokoa biteissä. Suositus on käyttää vähintään 1024 bittistä avainkokoa.
### encrypt
Salaa annetun viestin ja tallentaa sen tiedostoon. Ohjelma kysyy julkisen aviaimen polkua ja polkua mihin salattu viesti tallennetaan.
### decrypt
Purkaa salatun viestin annetulla salaisella avaimella. Ohjelma kysyy salaisen avaimen polkua ja salatun viestin polkua. Ohjelma tulostaa puretun viestin konsoliin.
### help
Ohjelma tulostaa konsoliin komennot
### exit
Ohjelma sulkeutuu
