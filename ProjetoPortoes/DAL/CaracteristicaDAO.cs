using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.DAL
{
    public class CaracteristicasDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static List<Caracteristicas> ListarCaracteristicas()
        {
            return entities.Caracteristicas.Include("Produto").ToList();
        }
        public static bool CadastrarCaracteristicas(Caracteristicas caracteristicas)
        {
            try
            {
                if (BuscarCaracteristicasPorNome(caracteristicas) == null)
                {
                    entities.Caracteristicas.Add(caracteristicas);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Caracteristicas BuscarCaracteristicasPorNome(Caracteristicas caracteristicas)
        {
            return entities.Caracteristicas.FirstOrDefault(x => x.Produto.Nome.Equals(caracteristicas.Produto.Nome));
        }
        public static Caracteristicas BuscarCaracteristicasPorId(int? id)
        {
            return entities.Caracteristicas.Find(id);
        }
        public static List<Caracteristicas> BuscarCaracteristicasNoProduto(int? id)
        {
            return entities.Caracteristicas.Include("Produto").Include("Produto.SubCategoria").Where(x => x.Produto.SubCategoria.SubCategoriaId == id).ToList();
        }
        public static Caracteristicas BuscarProdutoNaCaracteristica(Caracteristicas caracteristicas)
        {
            return entities.Caracteristicas.FirstOrDefault(x => x.CaracteristicaId == caracteristicas.CaracteristicaId);
        }

        public static bool AtualizarCaracteristicas(Caracteristicas caracteristicas)
        {
            try
            {
                entities.Entry(caracteristicas).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverCaracteristicas(Caracteristicas caracteristicas)
        {
            try
            {
                entities.Caracteristicas.Remove(caracteristicas);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}