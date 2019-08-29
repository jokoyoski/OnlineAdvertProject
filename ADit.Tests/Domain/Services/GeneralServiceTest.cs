using ADit.Domain.Models;
using ADit.Domain.Services;
using ADit.Interfaces;
using ADit.Repositories.Models;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;

namespace ADit.Tests.Domain.Services
{
    public class GeneralServiceTest
    {
        private IGeneralRepository generalRepository ;
        private IGeneralFactory generalFactory;
        private ILookupRepository lookupRepository;
        private GeneralService generalService;
        private IDesignElementView designElementView;
        private IDesignElement designElement;
        private IApconApprovalTypePriceView apconApprovalTypePrice;
        private IRadioServicePriceList radioServicePriceList;
        private IDesignElementPriceView elementPriceView;
        private IApconApprovalView apconApprovalView;
        private IApconApprovalType ApconApprovalType;
        private IColorView colorView;
        private IColor color;
        private IDurationTypeView durationTypeView;
        private IDesignElementPriceView designElementPriceView;
        private IDesignElementPrice designElementPrice;
        private IServiceType serviceType;
        private IDesignElement designElementModel;
        private ITimingView timingView;
        private ITiming timing;
        private IMaterialType materialType;
        private IMaterialTypeView materialTypeView;
      [SetUp]
      public void SetUp()
        {
            this.generalFactory =  MockRepository.GenerateMock<IGeneralFactory>();
            this.generalRepository = MockRepository.GenerateMock<IGeneralRepository>();
            this.lookupRepository = MockRepository.GenerateMock<ILookupRepository>();

            this.generalService = new GeneralService(this.generalRepository, this.generalFactory,  this.lookupRepository);
             designElementView = new DesignElementView {Description="desicription",DesignElementId=2 };
             designElement = new DesignElementModel { Description = "description", DesignElementId = 2 };
            apconApprovalTypePrice = new ApconApprovalTypePriceView { Amount = 2000, Comment = "ok" };
            radioServicePriceList = new RadioServicePriceListMain { Amount = 200, RadioId = 2 };
            elementPriceView = new DesignElementPriceView { Amount = 200, Comment = "ok" };
            apconApprovalView = new ApconApprovalView { ApconApprovalTypeId = 3, Description = "ok" };
            ApconApprovalType = new ApconApprovalTypeModel {ApoconTypeId= 3, Description = "ok" };
            colorView = new ColorView { ColorId = 2, Description = "ok" };
            color = new ColorModel { ColorId = 3, Description = "ok" };
            durationTypeView = new DurationTypeView { Description = "ok", DurationTypeCode = "B" };
            designElementPriceView = new DesignElementPriceView { Amount = 200, Comment = "ok" };
            designElementPrice = new DesignElementPriceModel { Amount = 200, Comment = "ok" };
            serviceType = new SericeTypeModel { Description = "ok" };
            designElementModel = new DesignElementModel { Description = "ok" };
            timing = new TimingModel { Description = "ok" };
            timingView = new TimingView { Description = "Ok" };
            materialType = new MaterialTypeModel { Description = "OK" };
            materialTypeView = new MaterialTypeView { MaterialTypeId = 2,Description="ok" };
        }



        [Test]
        public void GetDeleteDesignElement_should_call_DeleteDesignElementDescription_of_generalRepository()
        {
            int designElementId = 5;
            //setup
            this.generalRepository.Expect(p => p.DeleteDesignElementDescription(designElementId)).IgnoreArguments().Return(string.Empty);
            //act
            this.generalService.GetDeleteDesignElement(designElementId);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }

        [Test]
        public void GetEditDesignElemen_should_call_GetDesignDescriptionByValue_of_lookupRepository()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetDesignDescriptionByValue(designElementView.Description)).IgnoreArguments().Return(designElement);

            //act
            this.generalService.GetEditDesignElement(designElementView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        [Test]
        public void GetEditDesignElemen_should_call_saveDesignElementDescription_of_generalRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetDesignDescriptionByValue(designElementView.Description)).IgnoreArguments().Return(designElement);
            this.generalRepository.Expect(p => p.EditDesignElementDescription(designElementView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.GetEditDesignElement(designElementView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


        [Test]
        public void GetEditDesignElemen_should_return_View()
        {
            
            //setup
            this.lookupRepository.Stub(p => p.GetDesignDescriptionByValue(designElementView.Description)).IgnoreArguments().Return(designElement);
            this.generalRepository.Stub(p => p.EditDesignElementDescription(designElementView)).IgnoreArguments().Return(string.Empty);

            //act
           var model= this.generalService.GetEditDesignElement(designElementView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }

        [Test]
        public void ProcessApconApprovalTypePriceView_should_call_Save_Apcon_Price_of_generalRepository()
        {

           
            this.generalRepository.Expect(p => p.SaveApconPrice(apconApprovalTypePrice)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessApconApprovalTypePriceView(apconApprovalTypePrice);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        public void ProcessApconApprovalTypePriceView_should_throw_exception_if_info_is_null()
        {
           apconApprovalTypePrice= null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.ProcessApconApprovalTypePriceView(apconApprovalTypePrice));
        }

        [Test]
        public void ProcessRadioServicePriceView_should_call_SaveRadioServicePrice_of_generalRepository()
        {


            this.generalRepository.Expect(p => p.SaveRadioServicePrice(radioServicePriceList)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessRadioServicePriceView(radioServicePriceList);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        public void ProcessRadioServicePriceView_should_throw_exception_if_info_is_null()
        {
           radioServicePriceList = null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.ProcessRadioServicePriceView(radioServicePriceList));
        }



        [Test]
        public void GetDesignElementViewModel_should_call_GetDesignDescriptionByValue_of_lookupRepository()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetDesignDescriptionByValue(designElementView.Description)).IgnoreArguments().Return(designElement);

            //act
            this.generalService.GetDesignElementViewModel(designElementView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        [Test]
        public void GetDesignElementViewModel_should_call_SaveAddDesignElement_of_generalRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetDesignDescriptionByValue(designElementView.Description)).IgnoreArguments().Return(designElement);
            this.generalRepository.Expect(p => p.SaveAddDesignElement(designElementView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.GetDesignElementViewModel(designElementView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


        [Test]
        public void GetDesignElementViewModel_should_return_View()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetDesignDescriptionByValue(designElementView.Description)).IgnoreArguments().Return(designElement);
            this.generalRepository.Expect(p => p.SaveAddDesignElement(designElementView)).IgnoreArguments().Return(string.Empty);

            //act
            var model = this.generalService.GetEditDesignElement(designElementView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }





        [Test]
        public void ProcessEditElementPriceInfo_should_call_EditDesignElementTypePrice_generalRepository()
        {
            //setup
          
            this.generalRepository.Expect(p => p.EditDesignElementTypePrice(elementPriceView)).IgnoreArguments().Return(string.Empty);

            //act
            var model = this.generalService.ProcessEditElementPriceInfo(elementPriceView);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }


        [Test]
        public void ProcessApconView_should_call_GetDesignDescriptionByValue_of_lookupRepository()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetApconDescriptionByValue(apconApprovalView.Description)).IgnoreArguments().Return(ApconApprovalType);

            //act
            this.generalService.ProcessApconView(apconApprovalView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        [Test]
        public void ProcessApconView_should_call_SaveApcon_of_generalRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetApconDescriptionByValue(apconApprovalView.Description)).IgnoreArguments().Return(ApconApprovalType);
            this.generalRepository.Expect(p => p.SaveApcon(apconApprovalView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessApconView(apconApprovalView);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }


        [Test]
        public void ProcessApconView_should_return_View()
        {
            //setup


            this.lookupRepository.Stub(p => p.GetApconDescriptionByValue(apconApprovalView.Description)).IgnoreArguments().Return(ApconApprovalType);
            this.generalRepository.Stub(p => p.SaveApcon(apconApprovalView)).IgnoreArguments().Return(string.Empty);

            //act
          var model= this.generalService.ProcessApconView(apconApprovalView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }





        [Test]
        public void ProcessColorInfo_should_call_GetColorDescriptionByValue_of_lookupRepository()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetColorDescriptionByValue(colorView.Description)).IgnoreArguments().Return(color);

            //act
            this.generalService.ProcessColorInfo(colorView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


        [Test]
        public void ProcessEditScriptingPrice_should_callProcessEditScriptingPrice_of_generalRepositry()
        {
            //setup
            this.generalRepository.Expect(p => p.EditRadioServicePrice(radioServicePriceList)).IgnoreArguments().Return(string.Empty);

            
            //act
            this.generalService.ProcessEditScriptingPrice(radioServicePriceList);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }

        [Test]
        public void ProcessEditScriptingPrice_should_throw_exception_if_info_is_less_than_one()
        {
           radioServicePriceList = null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.ProcessEditScriptingPrice(radioServicePriceList));
        }

        [Test]
        public void ProcessColorInfo_should_call_SaveColorInfo_of_generalRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetColorDescriptionByValue(colorView.Description)).IgnoreArguments().Return(color);

            this.generalRepository.Expect(p => p.SaveColorInfo(colorView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessColorInfo(colorView);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }


        [Test]
        public void ProcessColorInfo_should_return_View()
        {
            //setup


            this.lookupRepository.Stub(p => p.GetColorDescriptionByValue(colorView.Description)).IgnoreArguments().Return(color);

            this.generalRepository.Stub(p => p.SaveColorInfo(colorView)).IgnoreArguments().Return(string.Empty);

            //act
          var model=  this.generalService.ProcessColorInfo(colorView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }

        [Test]
        public void ProcessDeleteApcon_should_call_DeleteApconApprovalType_of_generalRepository()
        {
            //setup
            this.generalRepository.Expect(p => p.DeleteApconApprovalType(apconApprovalView.ApconApprovalTypeId)).IgnoreArguments().Return(string.Empty);



            //act
            this.generalService.ProcessDeleteApcon(apconApprovalView.ApconApprovalTypeId);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }

        public void ProcessDeleteApcon_should_throw_exception_if_id_is_less_than_one()
        {
           int Id = -1;
            Assert.Throws<ArgumentNullException>(() => this.generalService.ProcessDeleteApcon(Id));
        }


        [Test]
        public void ProcessDeleteApconApprovalTypePrice_should_call_DeleteApconApprovalTypePrice_of_generalRepository()
        {
            //setup
            this.generalRepository.Expect(p => p.DeleteApconApprovalTypePrice(apconApprovalView.ApconApprovalTypeId)).IgnoreArguments().Return(string.Empty);



            //act
            this.generalService.ProcessDeleteApconApprovalTypePrice(apconApprovalView.ApconApprovalTypeId);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }


        [Test]
        public void ProcessDeleteRadioServicePrice_should_call_DeleteRadioServicePrice_of_generalRepository()
        {
            int Id = 5;
            //setup
            this.generalRepository.Expect(p => p.DeleteRadioServicePrice(Id)).IgnoreArguments().Return(string.Empty);



            //act
            this.generalService.ProcessDeleteRadioServicePrice(Id);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }




        [Test]
        public void ProcessDeleteDurationTypeInfo_should_call_DeleteDurationTypeInfo_of_generalRepository()
        {
            string Code = "D";
            //setup
            this.generalRepository.Expect(p => p.DeleteDurationTypeInfo(Code)).IgnoreArguments().Return(string.Empty);



            //act
            this.generalService.ProcessDeleteDurationTypeInfo(Code);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }



        [Test]
        public void ProcessDeleteMaterialTypeInfo_should_call_DeleteMaterialTypeInfo_of_generalRepository()
        {
            int Id = 5;
            //setup
            this.generalRepository.Expect(p => p.DeleteMaterialTypeInfo(Id)).IgnoreArguments().Return(string.Empty);



            //act
            this.generalService.ProcessDeleteMaterialTypeInfo(Id);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }

        [Test]
        public void ProcessDeleteMaterialTypeTiming_should_call_DeleteMaterialTypeTiming_of_generalRepository()
        {
            int Id = 5;
            //setup
            this.generalRepository.Expect(p => p.DeleteMaterialTypeTiming(Id)).IgnoreArguments().Return(string.Empty);



            //act
            this.generalService.ProcessDeleteMaterialTypeTiming(Id);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }

        [Test]
        public void ProcessDeleteTimingInfo_should_call_c_of_generalRepository()
        {
            int Id = 5;
            //setup
            this.generalRepository.Expect(p => p.DeleteTimingInfo(Id)).IgnoreArguments().Return(string.Empty);



            //act
            this.generalService.ProcessDeleteTimingInfo(Id);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }


        [Test]
        public void ProcessDurationTypeInfo_should_call_GetDurationTypeDescriptionByValue_of_lookupRepositry()
        {
         
            //setup
            this.lookupRepository.Expect(p => p.GetDurationTypeDescriptionByValue(durationTypeView.Description)).IgnoreArguments().Return(new DurationTypeModel());

            //act
            this.generalService.ProcessDurationTypeInfo(durationTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        [Test]
        public void ProcessDurationTypeInfo_should_call_SaveDurationTypeInfo_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetDurationTypeDescriptionByValue(durationTypeView.Description)).IgnoreArguments().Return(new DurationTypeModel());
            this.generalRepository.Expect(p => p.SaveDurationTypeInfo(durationTypeView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessDurationTypeInfo(durationTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


        [Test]
        public void ProcessDurationTypeInfo_should_return_View()
        {
            //setup
            //setup
            this.lookupRepository.Stub(p => p.GetDurationTypeDescriptionByValue(durationTypeView.Description)).IgnoreArguments().Return(new DurationTypeModel());
            this.generalRepository.Stub(p => p.SaveDurationTypeInfo(durationTypeView)).IgnoreArguments().Return(string.Empty);

            //act
           var model= this.generalService.ProcessDurationTypeInfo(durationTypeView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }



        [Test]
        public void ProcessEditApcon_should_call_EditApconApprovalType_of_generalRepositry()
        {

            //setup
            this.generalRepository.Expect(p => p.EditApconApprovalType(apconApprovalView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessEditApcon(apconApprovalView);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }


        public void ProcessEditApcon_should_throw_exception_if_info_is_null()
        {
            apconApprovalView = null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.ProcessEditApcon(apconApprovalView));
        }



        public void ProcessEditScriptingPrice_should_call_EditApconApprovalTypePrice_of_generalRepositry()
        {

            //setup
            this.generalRepository.Expect(p => p.EditApconApprovalTypePrice(apconApprovalTypePrice)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessEditScriptingPrice(apconApprovalTypePrice);
            //assert
            this.generalRepository.VerifyAllExpectations();
        }


        public void ProcessEditScriptingPrice_should_throw_exception_if_info_is_null()
        {
            apconApprovalTypePrice= null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.ProcessEditScriptingPrice(apconApprovalTypePrice));
        }

      
        [Test]
        public void ProcessMaterialTypeInfo_should_call_GetMaterialTypeDescriptionByValue_of_lookupRepository()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetMaterialTypeDescriptionByValue(materialTypeView.Description)).IgnoreArguments().Return(materialType);

            //act
            this.generalService.ProcessMaterialTypeInfo(materialTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


      
        [Test]
        public void ProcessMaterialTypeInfo_should_call_SaveMaterialTypeInfo_of_generalRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetMaterialTypeDescriptionByValue(materialTypeView.Description)).IgnoreArguments().Return(materialType);

            this.generalRepository.Expect(p => p.SaveMaterialTypeInfo(materialTypeView)).IgnoreArguments().Return(string.Empty);
            //act
            this.generalService.ProcessMaterialTypeInfo(materialTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }

     
        [Test]
        public void ProcessMaterialTypeInfo_should_return_View()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetMaterialTypeDescriptionByValue(materialTypeView.Description)).IgnoreArguments().Return(materialType);

            this.generalRepository.Stub(p => p.SaveMaterialTypeInfo(materialTypeView)).IgnoreArguments().Return(string.Empty);

            //act
            var model = this.generalService.ProcessMaterialTypeInfo(materialTypeView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }
     
        [Test]
        public void ProcessTimingIfo_should_call_GetTimingDescriptionByValue_of_lookupRepository()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetTimingDescriptionByValue(timingView.Description)).IgnoreArguments().Return(timing);

            //act
            this.generalService.ProcessTimingIfo(timingView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


    
        [Test]
        public void ProcessTimingIfo_should_call_SaveTimingInfo_of_generalRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetTimingDescriptionByValue(timingView.Description)).IgnoreArguments().Return(timing);
            this.generalRepository.Expect(p => p.SaveTimingInfo(timingView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.ProcessTimingIfo(timingView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }
    
   
        [Test]
        public void ProcessTimingIfo_should_return_View()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetTimingDescriptionByValue(timingView.Description)).IgnoreArguments().Return(timing);
            this.generalRepository.Stub(p => p.SaveTimingInfo(timingView)).IgnoreArguments().Return(string.Empty);

            //act
            var model = this.generalService.ProcessTimingIfo(timingView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }

        [Test]
        public void UpdateColorInfo_should_call_GetColorDescriptionByValue_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetColorDescriptionByValue(colorView.Description)).IgnoreArguments().Return(new ColorModel());

            //act
            this.generalService.UpdateColorInfo(colorView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }
       


        [Test]
        public void UpdateColorInfoo_should_call_EditColor_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetColorDescriptionByValue(colorView.Description)).IgnoreArguments().Return(new ColorModel());

            this.generalRepository.Expect(p => p.EditColor(colorView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.UpdateColorInfo(colorView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }

       

        [Test]
        public void UpdateColorInfo_should_return_View()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetColorDescriptionByValue(colorView.Description)).IgnoreArguments().Return(new ColorModel());

            this.generalRepository.Expect(p => p.EditColor(colorView)).IgnoreArguments().Return(string.Empty);


            //act
            var model = this.generalService.UpdateColorInfo(colorView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }
       
        public void UpdateColorInfo_void_should_throw_exception_if_info_is_null()
        {
           colorView = null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.UpdateColorInfo(colorView));
        }

       


        [Test]
        public void UpdateDurationTypeInfo_should_call_GetDurationTypeDescriptionByValue_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetDurationTypeDescriptionByValue(durationTypeView.Description)).IgnoreArguments().Return(new DurationTypeModel());

            //act
            this.generalService.UpdateDurationTypeInfo(durationTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        [Test]
        public void UpdateMaterialTypeInfo_should_call_EditDurationType_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetDurationTypeDescriptionByValue(durationTypeView.Description)).IgnoreArguments().Return(new DurationTypeModel());
            this.generalRepository.Expect(p => p.EditDurationType(durationTypeView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.UpdateDurationTypeInfo(durationTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


        [Test]
        public void UpdateDurationTypeInfo_should_return_View()
        {


            //setup
            this.lookupRepository.Stub(p => p.GetDurationTypeDescriptionByValue(durationTypeView.Description)).IgnoreArguments().Return(new DurationTypeModel());
            this.generalRepository.Stub(p => p.EditDurationType(durationTypeView)).IgnoreArguments().Return(string.Empty);

            //act
            var model=this.generalService.UpdateDurationTypeInfo(durationTypeView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }
        public void UpdateDurationTypeInfo_void_should_throw_exception_if_info_is_null()
        {
            durationTypeView = null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.UpdateDurationTypeInfo(durationTypeView));
        }


        [Test]
        public void UpdateMaterialTypeInfo_should_call_GetMaterialTypeDescriptionByValue_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetMaterialTypeDescriptionByValue(materialTypeView.Description)).IgnoreArguments().Return(materialType);

            //act
            this.generalService.UpdateMaterialTypeInfo(materialTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        [Test]
        public void UpdateMaterialTypeInfo_should_call_EditMaterialType_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetMaterialTypeDescriptionByValue(materialTypeView.Description)).IgnoreArguments().Return(materialType);

            this.generalRepository.Expect(p => p.EditMaterialType(materialTypeView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.UpdateMaterialTypeInfo(materialTypeView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


        [Test]
        public void UpdateMaterialTypeInfo_should_return_View()
        {

            //setup
            this.lookupRepository.Stub(p => p.GetMaterialTypeDescriptionByValue(materialTypeView.Description)).IgnoreArguments().Return(materialType);

            this.generalRepository.Stub(p => p.EditMaterialType(materialTypeView)).IgnoreArguments().Return(string.Empty);

            //act
            var model = this.generalService.UpdateMaterialTypeInfo(materialTypeView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }
        public void UpdateMaterialTypeInfo_void_should_throw_exception_if_info_is_null()
        {
           materialTypeView = null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.UpdateMaterialTypeInfo(materialTypeView));
        }


        [Test]
        public void UpdateTimingInfo_should_call_GetTimingDescriptionByValue_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Expect(p => p.GetTimingDescriptionByValue(timingView.Description)).IgnoreArguments().Return(timing);

            //act
            this.generalService.UpdateTimingInfo(timingView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }



        [Test]
        public void UpdateTimingInfo_should_call_EditTiming_of_lookupRepositry()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetTimingDescriptionByValue(timingView.Description)).IgnoreArguments().Return(timing);
            this.generalRepository.Expect(p => p.EditTiming(timingView)).IgnoreArguments().Return(string.Empty);

            //act
            this.generalService.UpdateTimingInfo(timingView);
            //assert
            this.lookupRepository.VerifyAllExpectations();
        }


        [Test]
        public void UpdateTimingInfo_should_return_View()
        {
            //setup
            this.lookupRepository.Stub(p => p.GetTimingDescriptionByValue(timingView.Description)).IgnoreArguments().Return(timing);
            this.generalRepository.Stub(p => p.EditTiming(timingView)).IgnoreArguments().Return(string.Empty);

            //act
            var model = this.generalService.UpdateTimingInfo(timingView);
            //assert
            Assert.AreEqual(typeof(string), model.GetType());
        }
        public void  UpdateTimingInfo_void_should_throw_exception_if_info_is_null()
        {
            timingView = null;
            Assert.Throws<ArgumentNullException>(() => this.generalService.UpdateTimingInfo(timingView));
        }

        [Test]
        public void getUpdatedDesignElementView_should_call_CreateUpdatedDesignElementPriceView_of_generalFactory()
        {
            List<IServiceType> serviceType = new List<IServiceType>();
            List<IDesignElement> designElement = new List<IDesignElement>();
            //setup
            this.lookupRepository.Stub(p => p.GetServiceType()).IgnoreArguments().Return(serviceType);
            this.lookupRepository.Stub(p => p.GetDesignElement()).IgnoreArguments().Return(designElement);
            this.generalFactory.Expect(p => p.CreateUpdatedDesignElementPriceView(designElementPriceView,designElement,serviceType)).IgnoreArguments().Return(designElementPriceView);

            //act
            this.generalService.getUpdatedDesignElementView(designElementPriceView);
            //assert
            this.generalFactory.VerifyAllExpectations();
        }



    }


}





