# Booking

# Documento di specifica
Creiamo la nostrta versione di Booking.com

## Gestione prenotazioni
- lo user potr? scegliere da una lista di destinazioni possibili (strutture disponibili)
- dopo aver scelto la destinazione potr? scegliere il periodo (periodi/posti disponibili)
- Prenotazione: dataDa, dataA, hotel, numeroPersone, utenteCheHaFattoLaPrenotazione

## Gestione ADMIN
- gestione strutture (CRUD) (almeno lettura + inserimento)
- visiualizzazione prenotazioni effettuate

## API

### USERS
- GET Tutte le Citta
- GET Tutte le Strutture
- GET Struttura By ID
- GET Tutte le Strutture By CittaID
- POST Verifica Disponibilita Prenotazione (dal, al, numeroposti, struttura)
- POST Verifica Disponibilita Prenotazione EASY (dal, al, numeroposti, struttura) => verificato soltanto che non ci siano gi? prenotazioni per quella stanza nel periodo selezionato
- POST Prenota

### ADMIN
- GET Tutte le Prenotazioni
- POST Creazione Citta
- POST Creazione Struttura (comprese stanze e relative disponibilit?)

## BLAZOR CLIENT

### USERS
- OPTIONAL: Aggiornare bootstrap
- Pagina Citta con elenco delle citta (compreso il numero di strutture presenti nella citta) del DB
    - Voce di Menu
    - Servizio per le chiamate API
    - Componente CittaList
    - Componente CittaPreview
