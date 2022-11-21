# Booking

# Documento di specifica
Creiamo la nostrta versione di Booking.com

## Gestione prenotazioni
- lo user potrà scegliere da una lista di destinazioni possibili (strutture disponibili)
- dopo aver scelto la destinazione potrà scegliere il periodo (periodi/posti disponibili)
- Prenotazione: dataDa, dataA, hotel, numeroPersone, utenteCheHaFattoLaPrenotazione

## Gestione ADMIN
- gestione strutture (CRUD) (almeno lettura + inserimento)
- visiualizzazione prenotazioni effettuate

## API

### USERS
- GET Tutte le Citta
- GET Tutte le strutture Strutture
- GET Tutte le strutture Strutture By CittaID
- GET Struttura By ID
- POST Verifica Disponibilita Prenotazione (dal, al, numeroposti, struttura)
- POST Prenota

### ADMIN
- GET Tutte le Prenotazioni
- POST Creazione Citta
- POST Creazione Struttura (comprese stanze e relative disponibilità)