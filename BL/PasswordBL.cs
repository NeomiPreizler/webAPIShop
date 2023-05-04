﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PasswordBL:IPasswordBL
    {

        public async Task<int> checkStrangePassword(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;//    string chekPassword = password;//     options = {//    translations: zxcvbnEnPackage.translations,//    graphs: zxcvbnCommonPackage.adjacencyGraphs,//    dictionary://    {//        ...zxcvbnCommonPackage.dictionary,//    ...zxcvbnEnPackage.dictionary,//    },//    }//zxcvbnOptions.setOptions(options)//zxcvbn(password)//    }
        }
    }
}