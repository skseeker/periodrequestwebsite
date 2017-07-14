Periodrequestwebsite
--------
Periodrequestwebsite is a windows service project, this windows service is used to periodically request a website.

If the ASP.NET Web application is not requested for a long time, it will be automatically closed. Use this program to periodically request your website to make the ASP.NET Web application is always running.

Using
--------
1.  Configure the target website in **App.config**:

```xml
  <targetWebsiteSetting intervalSecond="300">
    <websites>
      <add name="youraspdotnetweb" url="https://www.youraspdotnetweb.com"/>
    </websites>
  </targetWebsiteSetting>
```

2.  **Install.bat** is used to install the windows service
3.  **Uninstall.bat** is used to uninstall the windows service

> Please restart the service after updating the **App.config**.