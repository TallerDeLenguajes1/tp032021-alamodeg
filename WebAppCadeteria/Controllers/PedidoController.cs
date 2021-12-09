﻿using AutoMapper;
using Cadeteria.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCadeteria.Models.Repositorio;
using WebAppCadeteria.Models.ViewModels;

namespace WebAppCadeteria.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IMapper _mapper;
        private readonly PedidoRepositorio _pedidoRepositorio;
        private readonly CadeteRepositorio _cadeteRepositorio;
        private readonly ClienteRepositorio _clienteRepositorio;

        public PedidoController(ILogger<PedidoController> logger, IMapper mapper, PedidoRepositorio pedidoRepositorio, CadeteRepositorio cadeteRepositorio, ClienteRepositorio clienteRepositorio)
        {
            _logger = logger;
            _mapper = mapper;
            _pedidoRepositorio = pedidoRepositorio;
            _cadeteRepositorio = cadeteRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult MostrarPedidos()
        {
            MostrarPedidosVM pedidosYcadetes = new MostrarPedidosVM(_cadeteRepositorio.GetEntities(), _pedidoRepositorio.GetEntities());
            return View(pedidosYcadetes);
        }

        public IActionResult AddPedido(int id_cadete , int id_cliente)
        {
            var cadetes = _cadeteRepositorio.GetEntities();
            var clientes = _clienteRepositorio.GetEntities();

            if (id_cadete == 0 || id_cliente == 0)
            {
                return Redirect("MostrarPedidos");
            }
            else
            {
                //var tosave = _mapper.Map<Pedido>(pedido);
                Pedido ped = new();
                ped.Estado = Estado.NoEntregado;

                //_pedidoRepositorio.AddEntity(ped,id_cadete, id_cliente);

                return Redirect("MostrarPedidos");
            }

        }
        /*
    public IActionResult DeletePedido(int id_pedido)
    {
        _DB.Cadeteria.ListaCadetes.ForEach(cad => cad.ListadoPedidos.RemoveAll(ped => ped.Id == id_pedido));
        _DB.Cadeteria.ListaPedidos.RemoveAll(ped => ped.Id == id_pedido);
        _DB.SaveAllCadetes();
        _DB.SaveAllPedidos();
        PedidoViewModel MostrarPedidosVM = new PedidoViewModel(_DB.Cadeteria.ListaPedidos, _DB.Cadeteria.ListaCadetes);
        return View("MostrarPedidos", MostrarPedidosVM);
    }
        */

        public IActionResult ReasingPedido(int id_cadete, int id_pedido)
        {
            //PedidoViewModel MostrarPedidosVM = new PedidoViewModel();
            //var OldPedido = _DB.Cadeteria.ListaPedidos.Find(ped => ped.Id == id_pedido);
            //_DB.Cadeteria.ListaCadetes.ForEach(cad => cad.ListadoPedidos.RemoveAll(ped => ped.Id == id_pedido));
            //_DB.Cadeteria.ListaCadetes.Find(cad => cad.Id == id_cadete).CargarPedido(OldPedido);
            //_DB.SaveAllCadetes();
            return View("MostrarPedidos");
        }
    }
}