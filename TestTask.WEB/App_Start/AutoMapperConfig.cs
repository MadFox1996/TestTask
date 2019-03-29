using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.BLL.DTO;

namespace TestTask.WEB.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            TestTask.BLL.Config.AutoMapperConfig.Initialize();
        }
    }
}