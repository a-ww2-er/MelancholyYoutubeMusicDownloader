# 🎵 Melancholy YouTube Music Downloader

A powerful YouTube music downloader built with modern .NET technologies. Download your favorite music through a beautiful web interface or API endpoints.

<div align="center">

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![YouTube API](https://img.shields.io/badge/YouTube%20API-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://developers.google.com/youtube)

</div>

## 🌟 Features

- **Web Interface**: Beautiful, responsive web UI for easy music downloads
- **API Endpoint**: RESTful API for programmatic access
- **Batch Processing**: Download multiple songs at once
- **ZIP Compression**: Automatically compress and download multiple files
- **Error Handling**: Robust error handling and failed download tracking

## 🚀 Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommended) or any code editor

### Installation

1. Clone the repository
```bash
git clone https://github.com/a-ww2-er/melancholy-youtube-music-downloader.git
cd melancholy-youtube-music-downloader
```

2. Build the project
```bash
dotnet build
```

3. Run the application
```bash
dotnet run
```

## 📖 Usage

### Web Interface (MVC)

1. Navigate to `/services/urls` in your web browser
2. Enter YouTube URL(s) in the input field
3. Click "Process URLs"
4. Wait for processing to complete
5. Click "Download" to receive your ZIP file containing the music

### API Endpoint

#### Endpoint: `/api/UrlApi/url-upload`

**Request Format:**
```json
{
    "Urls": "https://youtu.be/K9O1dXr9HU8?si=tsBVoDc5f-vaMD0_"
}
```

**Response Format:**
```json
{
    "message": "Musics download request completed!",
    "success": true,
    "filesDownloadedCount": 1,
    "filesDownloaded": "the weeknd - blinding lights",
    "failedToDownload": ""
}
```

#### Using with API Testing Tools

##### Postman
1. Create a new POST request
2. Set URL to `{your-base-url}/api/UrlApi/url-upload`
3. Set Content-Type header to `application/json`
4. Add request body in JSON format
5. Send request

##### Insomnia
1. Create a new POST request
2. Set URL to `{your-base-url}/api/UrlApi/url-upload`
3. Select JSON body type
4. Add request body
5. Send request

## 📁 Project Structure

```
melancholy-youtube-music-downloader/
├── Controllers/
│   ├── UrlController.cs        # MVC Controller
│   └── UrlApiController.cs     # API Controller
├── Views/
│   └── Url/
│       └── Upload.cshtml       # Web Interface
├── Models/
│   └── UrlModel.cs            # Data Models
└── musics/                    # Downloaded Music Storage
```

## 🔧 Technical Details

- **MVC Controller**: `UrlController`
  - Route: `/services/urls`
  - Handles web interface
  - Provides ZIP download functionality

- **API Controller**: `UrlApiController`
  - Route: `/api/UrlApi/url-upload`
  - Handles API requests
  - Saves files to `musics` folder

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📝 License

This project is licensed under the Apache 2.0 License - see the [LICENSE](LICENSE) file for details.

## ✨ Author

Created with ❤️ by [a-ww2-er](https://github.com/a-ww2-er)

---

<div align="center">
Made with 🎵 for music lovers
</div>
