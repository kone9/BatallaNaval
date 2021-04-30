using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixearCamara : MonoBehaviour
{
    Camera camaraActual;

    // float defaulAncho;
    // float NuevaPosicionCamara;

    Vector2 pantallaActualDimension;//tamaño de pantalla actual

    //Varias dimensiones de pantalla de celulares
    
    //1080 X 1920 cualquiera de estos puede representar 
    Vector2 HuaweiP8 = new Vector2(1080, 1920);
    Vector2 XiaomiNote3y4 = new Vector2(1080, 1920);
    Vector2 XiaomiMi6 = new Vector2(1080, 1920);
    Vector2 XiaomiMiA1 = new Vector2(1080, 1920);
    Vector2 iPhone6Plus = new Vector2(1080, 1920);
    Vector2 iPhone6SPlus = new Vector2(1080, 1920);
    Vector2 iPhone7Plus = new Vector2(1080, 1920);
    Vector2 iPhone8Plus = new Vector2(1080, 1920);
    Vector2 SamsungGalaxyS4 = new Vector2(1080, 1920);
    Vector2 SamsungGalaxyS5 = new Vector2(1080, 1920);
    Vector2 GooglePixel = new Vector2(1080,1920);
    Vector2 GooglePixel2 = new Vector2(1080, 1920);
    Vector2 HTCOne = new Vector2(1080, 1920);
    Vector2 HTCOneM8yM9 = new Vector2(1080, 1920);
    Vector2 HTC10 = new Vector2(1080, 1920);
    Vector2 SonyXperiaM5 = new Vector2(1080 ,1920);
    Vector2 SonyXperiaZ2 = new Vector2(1080 ,1920);
    Vector2 SonyXperiaZ3 = new Vector2(1080 ,1920);
    Vector2 SonyXperiaZ5 = new Vector2(1080 ,1920);
    Vector2 SonyXperiaX = new Vector2(1080 ,1920);
    Vector2 SonyXperiaZ = new Vector2(1080 ,1920);
    Vector2 OnePlusX = new Vector2(1080 ,1920);
    Vector2 OnePlusOney2 = new Vector2(1080 ,1920);
    Vector2 OnePlus3 = new Vector2(1080 ,1920);
    Vector2 OnePlus6 = new Vector2(1080 ,1920);
    Vector2 HuaweiHonor5X = new Vector2(1080 ,1920);
    Vector2 HuaweiMate8 = new Vector2(1080 ,1920);
    Vector2 HuaweiHonor8 = new Vector2(1080 ,1920);
    Vector2 LGG5 = new Vector2(1080 ,1920);
    Vector2 MicrosoftSurfacePro = new Vector2(1080, 1920);
    Vector2 MicrosoftSurface3LTE = new Vector2(1080, 1920);

    //720 X 1280 cualquiera de estos puede representar 
    Vector2 SamsungGalaxyNexus = new Vector2(720 ,1280);
    Vector2 SamsungGalaxyS3 = new Vector2(720 ,1280);
    Vector2 SonyXperiaM4 = new Vector2(720 ,1280);
    Vector2 SamsungA5 = new Vector2(720 ,1280);
    Vector2 SamsungGalaxyNote2 = new Vector2(720 ,1280);
    Vector2 MotorolaMotoG = new Vector2(720, 1280);


    //1440 X 2560 cualquiera de estos puede representar 
    Vector2 GooglePixelXL = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS6 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS7 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote4 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote5 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote7 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote8 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote9 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS7Edge = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS7Active = new Vector2(1440 ,2560);
    Vector2 LGG4 = new Vector2(1440 ,2560);
    Vector2 GooglePixel3XL = new Vector2(1440 ,2960);
    Vector2 LGG3 = new Vector2(1440 ,2560);
    Vector2 HuaweiMate10 = new Vector2(1440 ,2560);
    Vector2 MicrosoftLumia950 = new Vector2(1440, 2560);
    Vector2 MotorolaNexus6 = new Vector2(1440, 2560);
    Vector2 MotorolaMotoZ = new Vector2(1440, 2560);
    Vector2 MotorolaMotoXStyle = new Vector2(1440, 2560);


    //750 X 1334 cualquiera de estos puede representar 
    Vector2 iPhone6 = new Vector2(750 , 1334);
    Vector2 iPhone6S = new Vector2(750 , 1334);

    //750 X 1334 cualquiera de estos puede representar 
    Vector2 iPhone7 = new Vector2(750,1334);
    Vector2 iPhone8 = new Vector2(750,1334);

    //750 X 1334 cualquiera de estos puede representar 
    Vector2 iPhone3GS = new Vector2(320, 480);

    //640 X 960 cualquiera de estos puede representar 
    Vector2 iPhone4 = new Vector2(640, 960);

    //640 X 1136 cualquiera de estos puede representar 
    Vector2 iPhone5 = new Vector2(640, 1136);

    //1440 X 2960 cualquiera de estos puede representar 
    Vector2 SamsungGalaxyS8 = new Vector2(1440 ,2960);
    Vector2 SamsungGalaxyS9 = new Vector2(1440 ,2960);

    //1200 X 1920 cualquiera de estos puede representar 
    Vector2 AsusTransformer = new Vector2(1200, 1920);
    Vector2 AmazonKindleFireHD89 = new Vector2(1200, 1920);

    //1200 X 1920 cualquiera de estos puede representar 
    Vector2 LGGPadX80 = new Vector2(1600, 1920);

    //480 X 800 cualquiera de estos puede representar 
    Vector2 SamsungGalaxyS = new Vector2(480 ,800);
    Vector2 SamsungGalaxyS2 = new Vector2(480 ,800);
    Vector2 HTCDesire = new Vector2(480 ,800);
    Vector2 HTCEvo = new Vector2(480 ,800);
    Vector2 NokiaLumia520 = new Vector2(480, 800);
    Vector2 NokiaLumia710y800 = new Vector2(480, 800);
   
    //480 X 800 cualquiera de estos puede representar 
    Vector2 SamsungGalaxyTab101 = new Vector2(800, 1280);
    Vector2 SamsungGalaxyTabS2101 = new Vector2(800, 1280);
    Vector2 SamsungGalaxyTabS84 = new Vector2(800, 1280);
    Vector2 HP8 = new Vector2(800, 1280);

    //1125 X 2046 cualquiera de estos puede representar 
    Vector2 iPhoneX = new Vector2(1125,2046);

    //828 X 1792 cualquiera de estos puede representar 
    Vector2 iPhoneXR = new Vector2(828 ,1792);

    //1125 X 2436 cualquiera de estos puede representar
    Vector2 iPhoneXS = new Vector2(1125 ,2436);
    Vector2 iPhone11Pro = new Vector2(1125 ,2436);
    
    //1242 X 2688 cualquiera de estos puede representar
    Vector2 iPhoneXSMax = new Vector2(1242 ,2688);
    Vector2 iPhone11ProMax = new Vector2(1242 ,2688);

    //828 X 1792 cualquiera de estos puede representar
    Vector2 iPhone11 = new Vector2(828 ,1792);

    //1440 X 2960 cualquiera de estos puede representar
    Vector2 SamsungGalaxyS9mas = new Vector2(1440 ,2960);

    //1440 X 2960 cualquiera de estos puede representar
    Vector2 SamsungGalaxyNote = new Vector2(800 ,1280);
    Vector2 GoogleNexus7byAsus = new Vector2(800, 1280);

    //1440 X 2880 cualquiera de estos puede representar
    Vector2 LGG6 = new Vector2(1440 ,2880);

    //1080 X 2160 cualquiera de estos puede representar
    Vector2 GooglePixel3 = new Vector2(1080 ,2160);
    Vector2 HuaweiMate10Plus = new Vector2(1080 ,2160);

    //1600 X 2560 cualquiera de estos puede representar
    Vector2 GoogleNexus10bySamsung = new Vector2(1600, 2560);
    Vector2 LenovoYogaTab3Pro = new Vector2(1600, 2560);

    //800 X 1280 cualquiera de estos puede representar
    Vector2 AmazonKindleFireHD7 = new Vector2(800, 1280);

    //1080 X 2248 cualquiera de estos puede representar
    Vector2 XiaomiMi8 = new Vector2(1080, 2248);

    //768 X 1280 cualquiera de estos puede representar
    Vector2 NokiaLumia920 = new Vector2(768, 1280);

    //480 X 854 cualquiera de estos puede representar
    Vector2 MotorolaDroid = new Vector2(480, 854);

    //540 X 960 cualquiera de estos puede representar
    Vector2 MotorolaDroid3y4 = new Vector2(540, 960);
    Vector2 MotorolaDroidRazr = new Vector2(540, 960);

    //768 X 1024 cualquiera de estos puede representar
    Vector2 AppleiPad1Y2 = new Vector2(768, 1024);
    Vector2 AppleiPadMini = new Vector2(768, 1024);

    //1536 X 2048 cualquiera de estos puede representar
    Vector2 AppleIPad3Y4 = new Vector2(1536, 2048);
    Vector2 AppleiPadAir1y2 = new Vector2(1536, 2048);
    Vector2 AppleiPadPro97LTE = new Vector2(1536, 2048);
    Vector2 AppleiPadMini4WiFi = new Vector2(1536, 2048);
    Vector2 AppleiPadMini2 = new Vector2(1536, 2048);
    Vector2 HTCGoogleNexus9 = new Vector2(1536, 2048);

    //1732 X 2048 cualquiera de estos puede representar
    Vector2 AppleiPadProLTE = new Vector2(1732, 2048);
    Vector2 AppleiPadProWiFi = new Vector2(1732, 2048);

    //600 X 800 cualquiera de estos puede representar                                                                                                                
    Vector2 BarnesYNobleNookTablet = new Vector2(600, 800);

    //600 X 1024 cualquiera de estos puede representar
    Vector2 HP7 = new Vector2(600, 1024);

    //1440 X 2160 cualquiera de estos puede representar
    Vector2 MicrosoftSurfacePro3 = new Vector2(1440, 2160);

    //1824 X 2736 cualquiera de estos puede representar
    Vector2 MicrosoftSurfacePro4 = new Vector2(1824, 2736);

    //2000 X 3000 cualquiera de estos puede representar
    Vector2 MicrosoftSurfaceBook = new Vector2(2000, 3000);

        //1700 X 2560 cualquiera de estos puede representar
    Vector2 ChromebookPixel = new Vector2(1700, 2560);



    private void Awake() {
        camaraActual = GetComponent<Camera>();
    }
    private void Start()
    {
        CalcularPosicionDeCamara();
    }


    void CalcularPosicionDeCamara()
    {
        //dependiendo el ancho de la pantalla cambio la posición en el eje "Y" de la Camara
        pantallaActualDimension = new Vector2(Screen.width,Screen.height);
        if(pantallaActualDimension == iPhone3GS)
        {
            camaraActual.transform.position = new Vector3(
                    this.transform.position.x,
                    75, //posicion de la camara en "Y"
                    this.transform.position.z
                );
        }
        else if(pantallaActualDimension == iPhone4)
        {

        }
        else if(pantallaActualDimension == iPhone5)
        {

        }
        else if(pantallaActualDimension == iPhone6)
        {

        }
        else if(pantallaActualDimension == iPhone6Plus)
        {

        }
        else if(pantallaActualDimension == iPhone6S)
        {

        }
        else if(pantallaActualDimension == iPhone6SPlus)
        {

        }
        else if(pantallaActualDimension == iPhone7)
        {

        }
        else if(pantallaActualDimension == iPhone7Plus)
        {

        }
        else if(pantallaActualDimension == iPhone8)
        {

        }
        else if(pantallaActualDimension == iPhone8Plus)
        {

        }
        else if(pantallaActualDimension == iPhoneX)
        {

        }
        else if(pantallaActualDimension == iPhoneXR)
        {

        }
        else if(pantallaActualDimension == iPhoneXS)
        {

        }
        else if(pantallaActualDimension == iPhoneXSMax)
        {

        }
        else if(pantallaActualDimension == iPhone11)
        {

        }
        else if(pantallaActualDimension == iPhone11Pro)
        {

        }
        else if(pantallaActualDimension == iPhone11ProMax)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNexus)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS2)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS3)
        {

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of d72d413 (agregando todas las resoluciones)
        }
        else if(pantallaActualDimension == SamsungGalaxyS4)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS5)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS6)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS7)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS7Edge)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS7Active)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS8)
        {

<<<<<<< HEAD
        }
        else if(pantallaActualDimension == SamsungGalaxyS9)
        {
=======
        }
        else if(pantallaActualDimension == SamsungGalaxyS9)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS9mas)
        {

        }
        else if(pantallaActualDimension == SamsungA5)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote2)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote4)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote5)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote7)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote8)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote9)
        {

        }
        else if(pantallaActualDimension == LGG3)
        {

        }
        else if(pantallaActualDimension == LGG4)
        {

        }
        else if(pantallaActualDimension == LGG5)
        {

        }
        else if(pantallaActualDimension == LGG6)
        {

        }
        else if(pantallaActualDimension == GooglePixel)
        {

        }
        else if(pantallaActualDimension == GooglePixelXL)
        {

        }
        else if(pantallaActualDimension == GooglePixel2)
        {

        }
        else if(pantallaActualDimension == GooglePixel3)
        {

        }
        else if(pantallaActualDimension == GooglePixel3XL)
        {

        }
        else if(pantallaActualDimension == HTCDesire)
        {

        }
        else if(pantallaActualDimension == HTCEvo)
        {

        }
        else if(pantallaActualDimension == HTCOne)
        {

        }
        else if(pantallaActualDimension == HTCOneM8yM9)
        {

        }
        else if(pantallaActualDimension == HTC10)
        {

        }
        else if(pantallaActualDimension == SonyXperiaM4)
        {

        }
        else if(pantallaActualDimension == SonyXperiaM5)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ2)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ3)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ5)
        {

        }
        else if(pantallaActualDimension == SonyXperiaX)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ)
        {

        }
        else if(pantallaActualDimension == OnePlusX)
        {

        }
        else if(pantallaActualDimension == OnePlusOney2)
        {

        }
        else if(pantallaActualDimension == OnePlus3)
        {

        }
        else if(pantallaActualDimension == OnePlus6)
        {

        }
        else if(pantallaActualDimension == HuaweiHonor5X)
        {

        }
        else if(pantallaActualDimension == HuaweiMate8)
        {

        }
        else if(pantallaActualDimension == HuaweiHonor8)
        {

        }
        else if(pantallaActualDimension == HuaweiMate10)
        {

        }
        else if(pantallaActualDimension == HuaweiMate10Plus)
        {

        }
        else if(pantallaActualDimension == HuaweiP8)
        {

        }
        else if(pantallaActualDimension == XiaomiNote3y4)
        {

        }
        else if(pantallaActualDimension == XiaomiMi6)
        {

        }
        else if(pantallaActualDimension == XiaomiMiA1)
        {

        }
        else if(pantallaActualDimension == XiaomiMi8)
        {

        }
        else if(pantallaActualDimension == NokiaLumia520)
        {

        }
        else if(pantallaActualDimension == NokiaLumia710y800)
        {

        }
        else if(pantallaActualDimension == NokiaLumia920)
        {

        }
        else if(pantallaActualDimension == MicrosoftLumia950)
        {

        }
        else if(pantallaActualDimension == MotorolaDroid)
        {

        }
        else if(pantallaActualDimension == MotorolaDroid3y4)
        {

        }
        else if(pantallaActualDimension == MotorolaDroidRazr)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoG)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoXStyle)
        {

        }
        else if(pantallaActualDimension == MotorolaNexus6)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoZ)
        {

        }
        else if(pantallaActualDimension == AppleiPad1Y2)
        {

        }
        else if(pantallaActualDimension == AppleIPad3Y4)
        {

        }
        else if(pantallaActualDimension == AppleiPadAir1y2)
        {

        }
        else if(pantallaActualDimension == AppleiPadProLTE)
        {

        }
        else if(pantallaActualDimension == AppleiPadProWiFi)
        {

        }
        else if(pantallaActualDimension == AppleiPadPro97LTE)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini2)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini4WiFi)
        {

        }
        else if(pantallaActualDimension == BarnesYNobleNookTablet)
        {

        }
        else if(pantallaActualDimension == GoogleNexus7byAsus)
        {

        }
        else if(pantallaActualDimension == HTCGoogleNexus9)
        {

        }
        else if(pantallaActualDimension == GoogleNexus10bySamsung)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTab101)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTabS2101)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTabS84)
        {

        }
        else if(pantallaActualDimension == HP7)
        {

        }
        else if(pantallaActualDimension == HP8)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurface3LTE)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro3)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro4)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfaceBook)
        {

        }
        else if(pantallaActualDimension == AmazonKindleFireHD7)
        {

        }
        else if(pantallaActualDimension == AmazonKindleFireHD89)
        {

        }
        else if(pantallaActualDimension == AsusTransformer)
        {

        }
        else if(pantallaActualDimension == LenovoYogaTab3Pro)
        {

        }
        else if(pantallaActualDimension == LGGPadX80)
        {

        }
        else if(pantallaActualDimension == ChromebookPixel)
        {

        }
>>>>>>> parent of d72d413 (agregando todas las resoluciones)

        }
        else if(pantallaActualDimension == SamsungGalaxyS9mas)
        {

        }
        else if(pantallaActualDimension == SamsungA5)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote2)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote4)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote5)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote7)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote8)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote9)
        {

        }
        else if(pantallaActualDimension == LGG3)
        {

        }
        else if(pantallaActualDimension == LGG4)
        {

        }
        else if(pantallaActualDimension == LGG5)
        {

        }
        else if(pantallaActualDimension == LGG6)
        {

        }
        else if(pantallaActualDimension == GooglePixel)
        {

        }
        else if(pantallaActualDimension == GooglePixelXL)
        {

        }
        else if(pantallaActualDimension == GooglePixel2)
        {

        }
        else if(pantallaActualDimension == GooglePixel3)
        {

        }
        else if(pantallaActualDimension == GooglePixel3XL)
        {

        }
        else if(pantallaActualDimension == HTCDesire)
        {

        }
        else if(pantallaActualDimension == HTCEvo)
        {

        }
        else if(pantallaActualDimension == HTCOne)
        {

        }
        else if(pantallaActualDimension == HTCOneM8yM9)
        {

        }
        else if(pantallaActualDimension == HTC10)
        {

        }
        else if(pantallaActualDimension == SonyXperiaM4)
        {

        }
        else if(pantallaActualDimension == SonyXperiaM5)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ2)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ3)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ5)
        {

        }
        else if(pantallaActualDimension == SonyXperiaX)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ)
        {

        }
        else if(pantallaActualDimension == OnePlusX)
        {

        }
        else if(pantallaActualDimension == OnePlusOney2)
        {

        }
        else if(pantallaActualDimension == OnePlus3)
        {

        }
        else if(pantallaActualDimension == OnePlus6)
        {

        }
        else if(pantallaActualDimension == HuaweiHonor5X)
        {

        }
        else if(pantallaActualDimension == HuaweiMate8)
        {

        }
        else if(pantallaActualDimension == HuaweiHonor8)
        {

        }
        else if(pantallaActualDimension == HuaweiMate10)
        {

        }
        else if(pantallaActualDimension == HuaweiMate10Plus)
        {

        }
        else if(pantallaActualDimension == HuaweiP8)
        {

        }
        else if(pantallaActualDimension == XiaomiNote3y4)
        {

        }
        else if(pantallaActualDimension == XiaomiMi6)
        {

        }
        else if(pantallaActualDimension == XiaomiMiA1)
        {

        }
        else if(pantallaActualDimension == XiaomiMi8)
        {

        }
        else if(pantallaActualDimension == NokiaLumia520)
        {

        }
        else if(pantallaActualDimension == NokiaLumia710y800)
        {

        }
        else if(pantallaActualDimension == NokiaLumia920)
        {

        }
        else if(pantallaActualDimension == MicrosoftLumia950)
        {

        }
        else if(pantallaActualDimension == MotorolaDroid)
        {

        }
        else if(pantallaActualDimension == MotorolaDroid3y4)
        {

        }
        else if(pantallaActualDimension == MotorolaDroidRazr)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoG)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoXStyle)
        {

        }
        else if(pantallaActualDimension == MotorolaNexus6)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoZ)
        {

        }
        else if(pantallaActualDimension == AppleiPad1Y2)
        {

        }
        else if(pantallaActualDimension == AppleIPad3Y4)
        {

        }
        else if(pantallaActualDimension == AppleiPadAir1y2)
        {

        }
        else if(pantallaActualDimension == AppleiPadProLTE)
        {

        }
        else if(pantallaActualDimension == AppleiPadProWiFi)
        {

        }
        else if(pantallaActualDimension == AppleiPadPro97LTE)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini2)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini4WiFi)
        {

        }
        else if(pantallaActualDimension == BarnesYNobleNookTablet)
        {

        }
        else if(pantallaActualDimension == GoogleNexus7byAsus)
        {

        }
        else if(pantallaActualDimension == HTCGoogleNexus9)
        {

        }
        else if(pantallaActualDimension == GoogleNexus10bySamsung)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTab101)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTabS2101)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTabS84)
        {

        }
        else if(pantallaActualDimension == HP7)
        {

        }
        else if(pantallaActualDimension == HP8)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurface3LTE)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro3)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro4)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfaceBook)
        {

        }
        else if(pantallaActualDimension == AmazonKindleFireHD7)
        {

        }
        else if(pantallaActualDimension == AmazonKindleFireHD89)
        {

        }
        else if(pantallaActualDimension == AsusTransformer)
        {

        }
        else if(pantallaActualDimension == LenovoYogaTab3Pro)
        {

        }
        else if(pantallaActualDimension == LGGPadX80)
        {

        }
        else if(pantallaActualDimension == ChromebookPixel)
        {

        }
<<<<<<< HEAD
        else if(pantallaActualDimension == new Vector2(600,800))
        {
            camaraActual.transform.position = new Vector3(
                this.transform.position.x,
                76, //posicion de la camara en "Y"
                this.transform.position.z
            );
        }
        else if(pantallaActualDimension == new Vector2(1440,2160))
=======
        }
        else if(pantallaActualDimension == SamsungGalaxyS4)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS5)
>>>>>>> parent of d72d413 (agregando todas las resoluciones)
        {

        }
<<<<<<< HEAD
        else if(pantallaActualDimension == new Vector2(1824,2736))
=======
        else if(pantallaActualDimension == SamsungGalaxyS6)
>>>>>>> parent of d72d413 (agregando todas las resoluciones)
        {

        }
<<<<<<< HEAD
        else if(pantallaActualDimension == new Vector2(2000,3000))
=======
        else if(pantallaActualDimension == SamsungGalaxyS7)
>>>>>>> parent of d72d413 (agregando todas las resoluciones)
        {

        }
<<<<<<< HEAD
        else if(pantallaActualDimension == new Vector2(2000,3000))
        {
            camaraActual.transform.position = new Vector3(
                this.transform.position.x,
                75, //posicion de la camara en "Y"
                this.transform.position.z
            );
        }
        else if(pantallaActualDimension == new Vector2(1700,2560))
        {
            camaraActual.transform.position = new Vector3(
                this.transform.position.x,
                75, //posicion de la camara en "Y"
                this.transform.position.z
            );
        }
        else if(pantallaActualDimension == new Vector2(720,1560))
        {
            camaraActual.transform.position = new Vector3(
                this.transform.position.x,
                92, //posicion de la camara en "Y"
                this.transform.position.z
            );
        }
=======
=======
        else if(pantallaActualDimension == SamsungGalaxyS7Edge)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS7Active)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS8)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS9)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyS9mas)
        {

        }
        else if(pantallaActualDimension == SamsungA5)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote2)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote4)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote5)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote7)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote8)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyNote9)
        {

        }
        else if(pantallaActualDimension == LGG3)
        {

        }
        else if(pantallaActualDimension == LGG4)
        {

        }
        else if(pantallaActualDimension == LGG5)
        {

        }
        else if(pantallaActualDimension == LGG6)
        {

        }
        else if(pantallaActualDimension == GooglePixel)
        {

        }
        else if(pantallaActualDimension == GooglePixelXL)
        {

        }
        else if(pantallaActualDimension == GooglePixel2)
        {

        }
        else if(pantallaActualDimension == GooglePixel3)
        {

        }
        else if(pantallaActualDimension == GooglePixel3XL)
        {

        }
        else if(pantallaActualDimension == HTCDesire)
        {

        }
        else if(pantallaActualDimension == HTCEvo)
        {

        }
        else if(pantallaActualDimension == HTCOne)
        {

        }
        else if(pantallaActualDimension == HTCOneM8yM9)
        {

        }
        else if(pantallaActualDimension == HTC10)
        {

        }
        else if(pantallaActualDimension == SonyXperiaM4)
        {

        }
        else if(pantallaActualDimension == SonyXperiaM5)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ2)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ3)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ5)
        {

        }
        else if(pantallaActualDimension == SonyXperiaX)
        {

        }
        else if(pantallaActualDimension == SonyXperiaZ)
        {

        }
        else if(pantallaActualDimension == OnePlusX)
        {

        }
        else if(pantallaActualDimension == OnePlusOney2)
        {

        }
        else if(pantallaActualDimension == OnePlus3)
        {

        }
        else if(pantallaActualDimension == OnePlus6)
        {

        }
        else if(pantallaActualDimension == HuaweiHonor5X)
        {

        }
        else if(pantallaActualDimension == HuaweiMate8)
        {

        }
        else if(pantallaActualDimension == HuaweiHonor8)
        {

        }
        else if(pantallaActualDimension == HuaweiMate10)
        {

        }
        else if(pantallaActualDimension == HuaweiMate10Plus)
        {

        }
        else if(pantallaActualDimension == HuaweiP8)
        {

        }
        else if(pantallaActualDimension == XiaomiNote3y4)
        {

        }
        else if(pantallaActualDimension == XiaomiMi6)
        {

        }
        else if(pantallaActualDimension == XiaomiMiA1)
        {

        }
        else if(pantallaActualDimension == XiaomiMi8)
        {

        }
        else if(pantallaActualDimension == NokiaLumia520)
        {

        }
        else if(pantallaActualDimension == NokiaLumia710y800)
        {

        }
        else if(pantallaActualDimension == NokiaLumia920)
        {

        }
        else if(pantallaActualDimension == MicrosoftLumia950)
        {

        }
        else if(pantallaActualDimension == MotorolaDroid)
        {

        }
        else if(pantallaActualDimension == MotorolaDroid3y4)
        {

        }
        else if(pantallaActualDimension == MotorolaDroidRazr)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoG)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoXStyle)
        {

        }
        else if(pantallaActualDimension == MotorolaNexus6)
        {

        }
        else if(pantallaActualDimension == MotorolaMotoZ)
        {

        }
        else if(pantallaActualDimension == AppleiPad1Y2)
        {

        }
        else if(pantallaActualDimension == AppleIPad3Y4)
        {

        }
        else if(pantallaActualDimension == AppleiPadAir1y2)
        {

        }
        else if(pantallaActualDimension == AppleiPadProLTE)
        {

        }
        else if(pantallaActualDimension == AppleiPadProWiFi)
        {

        }
        else if(pantallaActualDimension == AppleiPadPro97LTE)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini2)
        {

        }
        else if(pantallaActualDimension == AppleiPadMini4WiFi)
        {

        }
        else if(pantallaActualDimension == BarnesYNobleNookTablet)
        {

        }
        else if(pantallaActualDimension == GoogleNexus7byAsus)
        {

        }
        else if(pantallaActualDimension == HTCGoogleNexus9)
        {

        }
        else if(pantallaActualDimension == GoogleNexus10bySamsung)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTab101)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTabS2101)
        {

        }
        else if(pantallaActualDimension == SamsungGalaxyTabS84)
        {

        }
        else if(pantallaActualDimension == HP7)
        {

        }
        else if(pantallaActualDimension == HP8)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurface3LTE)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro3)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfacePro4)
        {

        }
        else if(pantallaActualDimension == MicrosoftSurfaceBook)
        {

        }
        else if(pantallaActualDimension == AmazonKindleFireHD7)
        {

        }
        else if(pantallaActualDimension == AmazonKindleFireHD89)
        {

        }
        else if(pantallaActualDimension == AsusTransformer)
        {

        }
        else if(pantallaActualDimension == LenovoYogaTab3Pro)
        {

        }
        else if(pantallaActualDimension == LGGPadX80)
        {

        }
        else if(pantallaActualDimension == ChromebookPixel)
        {

        }
>>>>>>> parent of d72d413 (agregando todas las resoluciones)


>>>>>>> parent of d72d413 (agregando todas las resoluciones)
        else
        {
            camaraActual.transform.position = new Vector3(
                    this.transform.position.x,
                    75, //posicion de la camara en "Y"
                    this.transform.position.z
                );
        }

    }

    // void Update()
    // {

    //     NuevaPosicionCamara = (75 * Screen.width) / 450; //regla de tres simple camara a 75 en "Y", patanlla inicial 450 con variable, pero no sirve

    //     camaraActual.transform.position = new Vector3(
    //             this.transform.position.x,
    //             75 - (NuevaPosicionCamara - 75), //solo sumo el ancho que voy teniendo pero no funciona
    //             this.transform.position.z
    //     );
        
    //     print("El temaño de la pantalla es: " + Screen.width);
    //     print("la nueva posiciond de la camara: " + NuevaPosicionCamara);
    // }

}
