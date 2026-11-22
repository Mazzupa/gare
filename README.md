# Gare e hackathon

Le soluzioni che ho scritto, da solo o in squadra, alle gare di programmazione e agli hackathon a cui ho partecipato da studente all'Università di Milano-Bicocca. Le tengo come ricordo: è codice scritto in poche ore e sotto pressione, quindi va letto per quello che è.

| Cartella | Evento | Quando | Linguaggio | Cosa c'è |
|---|---|---|---|---|
| [`reply-2018-training/`](reply-2018-training) | Reply Code Challenge, sandbox di allenamento | marzo 2018 | Java | Ricerca del percorso migliore su una griglia con una BFS |
| [`reply-2018/`](reply-2018) | Reply Code Challenge 2018 | marzo 2018 | Java | Euristica greedy per assegnare acquisti e progetti alle regioni sui quattro input «adventure» |
| [`hashcode-2019/`](hashcode-2019) | Google Hash Code 2019, qualificazione | febbraio 2019 | Java | Il problema delle foto e degli slideshow, con il team CHAD |
| [`reply-2019/`](reply-2019) | Reply Code Challenge 2019 | marzo 2019 | C# (WinForms) | Soluzione sulle cinque mappe (Victoria Lake, Himalayas, Budapest, Manhattan, Oceania), scritta con Raul Merelli |
| [`hack-the-cloud-2019/`](hack-the-cloud-2019) | Hack the Cloud, hackathon di GARR e Università di Milano-Bicocca | giugno 2019 | Java, Python | «Bettr», app Android e pipeline Elasticsearch/Spark del team CHAD (Come Home and Debug) |

## Com'è fatto il repository

Ogni cartella era un repository a sé. A novembre 2026 li ho uniti con `git subtree`, conservando tutti i commit originali, e ho tolto i file compilati e quelli dell'IDE. Il branch `archivio/reply-2018-training-pat` conserva un branch di lavoro della sandbox Reply 2018.
