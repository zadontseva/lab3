﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zadontseva03.Tools
{
    interface ILoaderOwner: INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        Boolean IsEnabled { get; set; }

    }
}
