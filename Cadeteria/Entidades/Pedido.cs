﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    public enum Estado { NOEntregado, Entregado = 1 };
    class Pedido
    {
        Guid id;
        string observacion;
        Cliente cliente;
        Estado estado;

        public Pedido(string observacion, string apellido, string dir, string tel)
        {
            this.id = Guid.NewGuid();
            this.observacion = observacion;
            this.estado = Estado.NOEntregado; //estado por defecto al crearlo
            this.cliente = new Cliente(apellido,dir,tel);
        }

        public Guid Id { get => id; set => id = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Estado Estado { get => estado; set => estado = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }

    }
}