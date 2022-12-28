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

## Koodin helpfile
Help tiedosto löytyy polusta ./RSA/RSA console app/Help/Documentation.chm

# RSA console app käyttöohje
## Komennot
### keys
Luo salaisen ja julkisen avainparin ja tallentaa ne tiedostoihin key.pub (julkinen avain) ja key.priv (salainen avain) haluttuun paikkaan. Ohjelma kysyy polkua mihin avaimet tallennetaan. Ohjelma kysyy myös avainten kokoa biteissä. Suositus on käyttää vähintään 1024 bittistä avainkokoa.
### encrypt
Salaa annetun viestin ja tallentaa sen tiedostoon. Ohjelma kysyy julkisen aviaimen polkua ja polkua mihin salattu viesti tallennetaan.
### decrypt
Purkaa salatun viestin annetulla salaisella avaimella. Ohjelma kysyy salaisen avaimen polkua ja salatun viestin polkua. Ohjelma tulostaa puretun viestin konsoliin.
HUOM! voit kirjoittaa pelkän tiedoston nimen (ilman kenoviivaa) jos tiedosto sijaitsee ohjelman juuressa. Muuten pitää koko polku määrittää.
### test
Test komennolla voit testata alkulukujen luonti algoritmia. Mielenkiintoinen testi on vertailla alkulukujen luontia pre-check toiminnolla ja ilman. Pre-check toiminnon voi joko suorittaa Erastostheneen seulalla johonkin lukuun asti, tai kovakoodatulla 100 ensimmäisellä alkuluvulla.

Koska alkulukujen luonti tapahtuu satunnaisilla numeroilla voi suoritusnopeus vaihdella testien välillä. Tästä syystä voi valita kuinka monta alkulukua ohjelma luo ja saada niistä keskiarvo. HUOM! Suurilla testimäärillä ( yli 30) voi testin suorittamiseen mennä paljonkin aikaa. Ilman alkutarkistusta ei ole suositeltavaa tehä enemmän kuin 10 testikertaa.
### help
Ohjelma tulostaa konsoliin komennot
### exit
Ohjelma sulkeutuu
