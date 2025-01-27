#region License
//  Copyright 2015-2021 John Källén
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pytocs.Core
{
    public class SymbolTable
    {
        private Dictionary<string, Symbol> symbols;

        public SymbolTable()
        {
            symbols = new Dictionary<string, Symbol>();
        }

        public SymbolTable(SymbolTable outer)
            : this()
        { 
        }

        public Symbol? GetSymbol(string name)
        {
            if (!symbols.TryGetValue(name, out Symbol s))
                s = null!;
            return s;
        }

        public Symbol Reference(string name)
        {
            if (!symbols.TryGetValue(name, out Symbol s))
            {
                s = new Symbol { Name = name };
                symbols.Add(s.Name, s);
            }
            return s;
        }
    }
}
