#### Flow of Entire Program

Client App
    ↓
HttpClient sends GET request
    ↓
Web API receives request
    ↓
API fetches data from DB
    ↓
API returns JSON
    ↓
Client receives JSON
    ↓
Newtonsoft converts JSON → C# objects
    ↓
Loop prints data