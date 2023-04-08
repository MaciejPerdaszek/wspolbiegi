using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;
using Logika;
using Model;

namespace Model
{
    public class Model : ModelAbstractAPI
    {
        #region private

        private readonly LogicAbstractAPI LogicApi;

        #endregion private

        #region public API

        public Model()
        {
            LogicApi = LogicAbstractAPI.CreateApi();
        }

        public override void CreateBalls(int amount)
        {
            LogicApi.CreateBalls(amount);  
        }

        public override ObservableCollection<IBall> getBalls()
        {
            return LogicApi.Balls;
        }
        #endregion public API

        #region IDisposable

        public override void Dispose()
        {
            LogicApi.Dispose();
        }



        #endregion
    }
}

