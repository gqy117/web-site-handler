using System;
using System.Web;
using System.IO;

    public class clsMyHandler  : IHttpHandler
    {

        public void ProcessRequest(System.Web.HttpContext context)
        {
            context.Response.Write("The page request is " + context.Request.RawUrl.ToString());
            StreamWriter sw = new StreamWriter(@"C:\requestLog.txt",true);
            sw.WriteLine("Page requested at " + DateTime.Now.ToString() + context.Request.RawUrl); sw.Close();
        }
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

    }
    public class clsMyModule : IHttpModule
    {
        public clsMyModule()
        {}
        public void Init(HttpApplication objApplication)
        {
            // Register event handler of the piple line
            objApplication.BeginRequest += new EventHandler(this.context_BeginRequest);
            objApplication.EndRequest += new EventHandler(this.context_EndRequest);
        }
        public void Dispose()
        {

        }
        public void context_EndRequest(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\requestLog.txt",true);
            sw.WriteLine("End Request called at " + DateTime.Now.ToString()); sw.Close();
        }
        public void context_BeginRequest(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\requestLog.txt",true);
            sw.WriteLine("Begin request called at " + DateTime.Now.ToString()); sw.Close();
        }
        
    }

