using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixearCamara : MonoBehaviour
{
    Camera camaraActual;

    // float defaulAncho;
    // float NuevaPosicionCamara;

    Vector2 pantallaActualDimension;

    //referencia a dimensiones de pantalla de celulares
    Vector2 iPhone3GS = new Vector2(320, 480);
    Vector2 iPhone4 = new Vector2(640, 960);
    Vector2 iPhone5 = new Vector2(640, 1136);
    Vector2 iPhone6 = new Vector2(750 , 1334);
    Vector2 iPhone6Plus = new Vector2(1080  , 1920);
    Vector2 iPhone6S = new Vector2(750 , 1334);
    Vector2 iPhone6SPlus = new Vector2(1920 , 1080);
    Vector2 iPhone7 = new Vector2(1334 , 750);
    Vector2 iPhone7Plus = new Vector2(1080 , 1920);
    Vector2 iPhone8 = new Vector2(1334 , 750);
    Vector2 iPhone8Plus = new Vector2(1920 ,1080);
    Vector2 iPhoneX = new Vector2(2046 ,1125);
    Vector2 iPhoneXR = new Vector2(828 ,1792);
    Vector2 iPhoneXS = new Vector2(1125 ,2436);
    Vector2 iPhoneXSMax = new Vector2(1242 ,2688);
    Vector2 iPhone11 = new Vector2(828 ,1792);
    Vector2 iPhone11Pro = new Vector2(1125 ,2436);
    Vector2 iPhone11ProMax = new Vector2(1242 ,2688);
    Vector2 SamsungGalaxyNexus = new Vector2(720 ,1280);
    Vector2 SamsungGalaxyS = new Vector2(480 ,800);
    Vector2 SamsungGalaxyS2 = new Vector2(480 ,800);
    Vector2 SamsungGalaxyS3 = new Vector2(720 ,1280);
    Vector2 SamsungGalaxyS4 = new Vector2(1080 ,1920);
    Vector2 SamsungGalaxyS5 = new Vector2(1080 ,1920);
    Vector2 SamsungGalaxyS6 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS7 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS7Edge = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS7Active = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyS8 = new Vector2(1440 ,2960);
    Vector2 SamsungGalaxyS9 = new Vector2(1440 ,2960);
    Vector2 SamsungGalaxyS9mas = new Vector2(1440 ,2960);
    Vector2 SamsungA5 = new Vector2(720 ,1280);
    Vector2 SamsungGalaxyNote = new Vector2(800 ,1280);
    Vector2 SamsungGalaxyNote2 = new Vector2(720 ,1280);
    Vector2 SamsungGalaxyNote4 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote5 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote7 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote8 = new Vector2(1440 ,2560);
    Vector2 SamsungGalaxyNote9 = new Vector2(1440 ,2560);
    Vector2 LGG3 = new Vector2(1440 ,2560);
    Vector2 LGG4 = new Vector2(1440 ,2560);
    Vector2 LGG5 = new Vector2(1080 ,1920);
    Vector2 LGG6 = new Vector2(1440 ,2880);
    Vector2 GooglePixel = new Vector2(1080 ,1920);
    Vector2 GooglePixelXL = new Vector2(1440 ,2560);
    Vector2 GooglePixel2 = new Vector2(1080 ,1920);
    Vector2 GooglePixel3 = new Vector2(1080 ,2160);
    Vector2 GooglePixel3XL = new Vector2(1440 ,2960);
    Vector2 HTCDesire = new Vector2(480 ,800);
    Vector2 HTCEvo = new Vector2(480 ,800);
    Vector2 HTCOne = new Vector2(1080 ,1920);
    Vector2 HTCOneM8yM9 = new Vector2(1080 ,1920);
    Vector2 HTC10 = new Vector2(1080 ,1920);
    Vector2 SonyXperiaM4 = new Vector2(720 ,1280);
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
    Vector2 HuaweiMate10 = new Vector2(1440 ,2560);
    Vector2 HuaweiMate10Plus = new Vector2(1080 ,2160);
    Vector2 HuaweiP8 = new Vector2(1080, 1920);
    Vector2 XiaomiNote3y4 = new Vector2(1080, 1920);
    Vector2 XiaomiMi6 = new Vector2(1080, 1920);
    Vector2 XiaomiMiA1 = new Vector2(1080, 1920);
    Vector2 XiaomiMi8 = new Vector2(1080, 2248);
    Vector2 NokiaLumia520 = new Vector2(480, 800);
    Vector2 NokiaLumia710y800 = new Vector2(480, 800);
    Vector2 NokiaLumia920 = new Vector2(768, 1280);
    Vector2 MicrosoftLumia950 = new Vector2(1440, 2560);
    Vector2 MotorolaDroid = new Vector2(480, 854);
    Vector2 MotorolaDroid3y4 = new Vector2(540, 960);
    Vector2 MotorolaDroidRazr = new Vector2(540, 960);
    Vector2 MotorolaMotoG = new Vector2(720, 1280);
    Vector2 MotorolaMotoXStyle = new Vector2(1440, 2560);
    Vector2 MotorolaNexus6 = new Vector2(1440, 2560);
    Vector2 MotorolaMotoZ = new Vector2(1440, 2560);
    Vector2 AppleiPad1Y2 = new Vector2(768, 1024);
    Vector2 AppleIPad3Y4 = new Vector2(1536, 2048);
    Vector2 AppleiPadAir1y2 = new Vector2(1536, 2048);
    Vector2 AppleiPadProLTE = new Vector2(1732, 2048);
    Vector2 AppleiPadProWiFi = new Vector2(1732, 2048);
    Vector2 AppleiPadPro97LTE = new Vector2(1536, 2048);
    Vector2 AppleiPadMini = new Vector2(768, 1024);
    Vector2 AppleiPadMini2 = new Vector2(1536, 2048);
    Vector2 AppleiPadMini4WiFi = new Vector2(1536, 2048);
    Vector2 BarnesYNobleNookTablet = new Vector2(600, 800);
    Vector2 GoogleNexus7byAsus = new Vector2(800, 1280);
    Vector2 HTCGoogleNexus9 = new Vector2(1536, 2048);
    Vector2 GoogleNexus10bySamsung = new Vector2(1600, 2560);
    Vector2 SamsungGalaxyTab101 = new Vector2(800, 1280);
    Vector2 SamsungGalaxyTabS2101 = new Vector2(800, 1280);
    Vector2 SamsungGalaxyTabS84 = new Vector2(800, 1280);
    Vector2 HP7 = new Vector2(600, 1024);
    Vector2 HP8 = new Vector2(800, 1280);
    Vector2 MicrosoftSurfacePro = new Vector2(1080, 1920);
    Vector2 MicrosoftSurface3LTE = new Vector2(1080, 1920);
    Vector2 MicrosoftSurfacePro3 = new Vector2(1440, 2160);
    Vector2 MicrosoftSurfacePro4 = new Vector2(1824, 2736);
    Vector2 MicrosoftSurfaceBook = new Vector2(2000, 3000);
    Vector2 AmazonKindleFireHD7 = new Vector2(800, 1280);
    Vector2 AmazonKindleFireHD89 = new Vector2(1200, 1920);
    Vector2 AsusTransformer = new Vector2(1200, 1920);
    Vector2 LenovoYogaTab3Pro = new Vector2(1600, 2560);
    Vector2 LGGPadX80 = new Vector2(1600, 1920);
    Vector2 ChromebookPixel = new Vector2(1700, 2560);

















































































    private void Awake() {
        camaraActual = GetComponent<Camera>();
    }
    private void Start() {
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
        else if(pantallaActualDimension == iPhone3GS)
        {

        }

        // switch (pantallaActualDimension)
        // {
        //     case iPhone3GS:
        //         camaraActual.transform.position = new Vector3(
        //             this.transform.position.x,
        //             75, //posicion de la camara en "Y"
        //             this.transform.position.z
        //         );
        //         break;

        //     case 720:
        //         camaraActual.transform.position = new Vector3(
        //             this.transform.position.x,
        //             91, //posicion de la camara en "Y"
        //             this.transform.position.z
        //         );
        //         break;

        //     case 828:
        //         camaraActual.transform.position = new Vector3(
        //             this.transform.position.x,
        //             91, //posicion de la camara en "Y"
        //             this.transform.position.z
        //         );
        //         break;

        //     case 750:
        //         camaraActual.transform.position = new Vector3(
        //             this.transform.position.x,
        //             91, //posicion de la camara en "Y"
        //             this.transform.position.z
        //         );
        //         break;

        //     case 1125:
        //         camaraActual.transform.position = new Vector3(
        //             this.transform.position.x,
        //             91, //posicion de la camara en "Y"
        //             this.transform.position.z
        //         );
        //         break;

        //     case 640:
        //         camaraActual.transform.position = new Vector3(
        //             this.transform.position.x,
        //             91, //posicion de la camara en "Y"
        //             this.transform.position.z
        //         );
        //         break;

        //     default:
        //         camaraActual.transform.position = new Vector3(
        //                 this.transform.position.x,
        //                 75, //posicion de la camara en "Y"
        //                 this.transform.position.z
        //             );
        //         break;
        // }
        
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
