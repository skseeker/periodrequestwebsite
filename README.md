Periodrequestwebsite
--------
Periodrequestwebsite is a windows service project, this windows service is used to periodically request a Web site.

If the ASP.NET Web application is not requested for a long time, it will be automatically closed. Use this program to periodically request an ASP.NET Web application to make that the Web application is always running.

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

> Please restart the service after changing the configuration file