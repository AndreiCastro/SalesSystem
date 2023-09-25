﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SalesSystem.Mvc.Enums;
using System;
using System.ComponentModel.Design;
using static SalesSystem.Mvc.Enums.Enumeradores;

namespace SalesSystem.Mvc.Helpers
{
    public class Helper
    {
        public static string RetornaDescricaoEnum(int valor, string enumerador)
        {
            switch (enumerador)
            {
                case "UF":
                    UnidadeFederativa ufFormatado = (UnidadeFederativa)Convert.ToInt32(valor);
                    return ufFormatado.ToString();
                    
                case "UM":
                    UnidadeMedida unidadeMedidaFormatado = (UnidadeMedida)Convert.ToInt32(valor);
                    return unidadeMedidaFormatado.ToString();

                default:
                    return "";
            }            
        }
    }
}
