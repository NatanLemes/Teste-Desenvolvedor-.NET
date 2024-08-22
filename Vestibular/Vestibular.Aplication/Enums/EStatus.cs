﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vestibular.Aplication.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EStatus
    {
        EmAndamento,
        Aprovada,
        Cancelada,
        Reprovada
    }
}
