namespace PeriodRequestWebsite.WindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PeriodRequestWebsiteServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.PeriodRequestWebsiteServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // PeriodRequestWebsiteServiceProcessInstaller
            // 
            this.PeriodRequestWebsiteServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.PeriodRequestWebsiteServiceProcessInstaller.Password = null;
            this.PeriodRequestWebsiteServiceProcessInstaller.Username = null;
            // 
            // PeriodRequestWebsiteServiceInstaller
            // 
            this.PeriodRequestWebsiteServiceInstaller.Description = "用于周期性请求ASP.NET网站，保证网站一直运行";
            this.PeriodRequestWebsiteServiceInstaller.DisplayName = "PRWS";
            this.PeriodRequestWebsiteServiceInstaller.ServiceName = "PeriodRequestWebsiteService";
            this.PeriodRequestWebsiteServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.PeriodRequestWebsiteServiceProcessInstaller,
            this.PeriodRequestWebsiteServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller PeriodRequestWebsiteServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller PeriodRequestWebsiteServiceInstaller;
    }
}