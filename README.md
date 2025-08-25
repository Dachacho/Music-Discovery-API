# MusicAPI

A minimal Web API for music and playlist management.

## Features

- User registration & JWT authentication
- CRUD for songs and playlists
- Public/private playlists
- Add/remove songs to playlists
- Get all public playlists (no login required)

## API Documentation

Interactive API docs available at `/swagger` when running the app.

## Seeded Data

The database is seeded with fake users, songs, and playlists in `MusicDiscoveryContext` for testing/demo purposes.

## Model Relationships

- **User**: Can create multiple playlists
- **Playlist**: Belongs to a user, can be public or private, contains many songs
- **Song**: Can belong to many playlists

## Notes

- No external integrations (e.g., Spotify) in this lean version
- Focused on core music/playlist management and public sharing
- No real goal with this (somethings are very loosey goosey)
- No Recommendations

_to make this fully functional_:

- make recommendation system
- fully structure the endpoints with authorization
- Integrate Spotify API for actual info
