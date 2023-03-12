﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Features.Diff.Commands
{
    public class CreateDiffCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string Way { get; set; }

    }
}
