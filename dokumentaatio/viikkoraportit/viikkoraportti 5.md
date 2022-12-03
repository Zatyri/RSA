# Viikkoraportti 5

# Mitä tein viikon aikana
Aloitin viikon tekemällä pientä hienosäätöä käyttöliittymään. Paransin myös alkulukujen luontologiikkaa lisäämällä metodin joka tekee kevyen tarkistuksen alkulukuehdokkaalle ennen Miller-Rabin testiä. Tämä paransi alkulukujen luontinopeutta huimasti. 512 bittisen alkuluvun luonti kesti ennen alkutarkistusta noin 360ms. Alkulukutarkistuksen jälkeen tippui aika noin 170ms. Tein myös PKSC#1.5 padding toiminnon, jolloin kaksi samaa viestiä salattuna eivät ole identtiset. Tein myös testi toiminnon ohjelmaan jolla alkulukujen luontia voi testata, alkutarkistuksen kanssa tai ilman.

Käytin viikon aikana noin 10 tuntia

# Mitä opin
Oli mielenkiintoista nähdä miten paljon parannusta alkutarkistuksella sai aikaan.

# Tämä on epäselvää
Kaikki on tällä erää selvää

# Mitä seuraavaksi
Ohjelma alkaa olee melko valmis ja seuraavalla viikolla aloitan toteuttamani algoritmien O-analyysit ja tutkin voinko parannella niitä nykyisestään
