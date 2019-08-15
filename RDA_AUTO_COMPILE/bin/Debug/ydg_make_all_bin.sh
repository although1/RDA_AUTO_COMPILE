#export CC=/usr/bin/gcc
#在编译之前要确定的东西，首先要制定好customer，logo，IR
#其次，要make mconfig 并选好要编译的第一个屏参，比如本文件为CLAA170EA10_1280x1024
#最后本脚本一共有七处需要手动修改，有些可以不改，加了*的是必改
#在编译之前要先生成存放软件的目录，请先看‘需要改一’

#需要改一
#OUT_BIN_PATH：这个是生成在根目录的文件夹，里面存放软件，可以不改
OUT_BIN_PATH=./YDG_SOFTWARE

#需要改二 *
#OUT_BIN_NAME：这个是生成软件的文件名
#WORK_PATH：是你代码的根目录
OUT_BIN_NAME=YDG.512L.bin
WORK_PATH=rda_dtv

#需要改三 *
#以下四个是customize.h 中你建立好的customer，用于切换customize.h中的4:3,16:9
C4_3COSTOMER_OPEN="#define ENABLE_YSK_FRENCH_TR5LA81_2AV_YSK5LA811_ENGLISH_KPD_LUCKY_LOGO_4_3"
C4_3COSTOMER_CLOSE="//#define ENABLE_YSK_FRENCH_TR5LA81_2AV_YSK5LA811_ENGLISH_KPD_LUCKY_LOGO_4_3"
C16_9COSTOMER_OPEN="#define ENABLE_YSK_FRENCH_TR5LA81_2AV_YSK5LA812_ENGLISH_KPD_LUCKY_LOGO_16_9"
C16_9COSTOMER_CLOSE="//#define ENABLE_YSK_FRENCH_TR5LA81_2AV_YSK5LA812_ENGLISH_KPD_LUCKY_LOGO_16_9"

#需要改四 *
#iConfigNumber：是最大屏参数，若当前最大为14，则填15
iConfigNumber=30

#需要改五 *

#i4_3Index：是16:9的第一个屏参的编号，用于切换customize.h中的4:3,16:9
i4_3Index=22

########################
#
# Generate Panel data
#
########################
#############################################   4:3   #########################################

#注意panel_name中的x按照屏参名来写
#注意panel_n_UP中的x一律大写
#注意resolution中的x一律小写


# AA150XC01_1024X768
panel_name[0]=AA150XC01_1024X768
panel_n_UP[0]=AA150XC01_1024X768
resolution[0]=1024x768

# CLAA150XG_01F_DUAL_T49B_1024X768
panel_name[1]=CLAA150XG_01F_DUAL_T49B_1024X768
panel_n_UP[1]=CLAA150XG_01F_DUAL_T49B_1024X768
resolution[1]=1024x768

# CLAA150XG02_DUAL_S50_1024X768
panel_name[2]=CLAA150XG02_DUAL_S50_1024X768
panel_n_UP[2]=CLAA150XG02_DUAL_S50_1024X768
resolution[2]=1024x768

# CLAA150XG02_HW_TCON_V3_1024X768
panel_name[3]=CLAA150XG02_HW_TCON_V3_1024X768
panel_n_UP[3]=CLAA150XG02_HW_TCON_V3_1024X768
resolution[3]=1024x768

# CPT150XP02S_BX_HC_D50_1024X768
panel_name[4]=CPT150XP02S_BX_HC_D50_1024X768
panel_n_UP[4]=CPT150XP02S_BX_HC_D50_1024X768
resolution[4]=1024x768

# G150XG02_V0_1024X768
panel_name[5]=G150XG02_V0_1024X768
panel_n_UP[5]=G150XG02_V0_1024X768
resolution[5]=1024x768

# HSD150SX84_1024X768
panel_name[6]=HSD150SX84_1024X768
panel_n_UP[6]=HSD150SX84_1024X768
resolution[6]=1024x768

# HSD150SX84_HW_TCON_V3_1024X768
panel_name[7]=HSD150SX84_HW_TCON_V3_1024X768
panel_n_UP[7]=HSD150SX84_HW_TCON_V3_1024X768
resolution[7]=1024x768

# L150X1M_1_DUAL_1024X768
panel_name[8]=L150X1M_1_DUAL_1024X768
panel_n_UP[8]=L150X1M_1_DUAL_1024X768
resolution[8]=1024x768

# LM151X3_B3AP_BX_HC_TMDS_1024X768
panel_name[9]=LM151X3_B3AP_BX_HC_TMDS_1024X768
panel_n_UP[9]=LM151X3_B3AP_BX_HC_TMDS_1024X768
resolution[9]=1024x768

# M150XN05_V3_ZD102J_40_30_1024X768
panel_name[10]=M150XN05_V3_ZD102J_40_30_1024X768
panel_n_UP[10]=M150XN05_V3_ZD102J_40_30_1024X768
resolution[10]=1024x768

# NL10276AC30_04_1024X768
panel_name[11]=NL10276AC30_04_1024X768
panel_n_UP[11]=NL10276AC30_04_1024X768
resolution[11]=1024x768

# QD15XR01_D50_T49A_1024X768
panel_name[12]=QD15XR01_D50_T49A_1024X768
panel_n_UP[12]=QD15XR01_D50_T49A_1024X768
resolution[12]=1024x768

# QD15XR01_JTR150V2_1024X768
panel_name[13]=QD15XR01_JTR150V2_1024X768
panel_n_UP[13]=QD15XR01_JTR150V2_1024X768
resolution[13]=1024x768

# SVA150XG04TB_1024X768
panel_name[14]=SVA150XG04TB_1024X768
panel_n_UP[14]=SVA150XG04TB_1024X768
resolution[14]=1024x768

# AUO_A201SN02_800X600
panel_name[15]=AUO_A201SN02_800X600
panel_n_UP[15]=AUO_A201SN02_800X600
resolution[15]=800x600

# CLAA170EA10_1280X1024
panel_name[16]=CLAA170EA10_1280X1024
panel_n_UP[16]=CLAA170EA10_1280X1024
resolution[16]=1280x1024

# CMO_M201P1_L01_1400X1050
panel_name[17]=CMO_M201P1_L01_1400X1050
panel_n_UP[17]=CMO_M201P1_L01_1400X1050
resolution[17]=1400x1050

# LC201V02_640X480
panel_name[18]=LC201V02_640X480
panel_n_UP[18]=LC201V02_640X480
resolution[18]=640x480

# LM201U04_A3K2_1600X1200
panel_name[19]=LM201U04_A3K2_1600X1200
panel_n_UP[19]=LM201U04_A3K2_1600X1200
resolution[19]=1600x1200

# LM201U04_A3K4_1600X1200
panel_name[20]=LM201U04_A3K4_1600X1200
panel_n_UP[20]=LM201U04_A3K4_1600X1200
resolution[20]=1600x1200

# LTM150X0_L01_1024X768
panel_name[21]=LTM150X0_L01_1024X768
panel_n_UP[21]=LTM150X0_L01_1024X768
resolution[21]=1024x768

#############################################   16:9   #########################################

# AUO_T420HW04_V0_1920X1080
panel_name[22]=AUO_T420HW04_V0_1920X1080
panel_n_UP[22]=AUO_T420HW04_V0_1920X1080
resolution[22]=1920x1080

# CMO_M185B1_L02_1366X768
panel_name[23]=CMO_M185B1_L02_1366X768
panel_n_UP[23]=CMO_M185B1_L02_1366X768
resolution[23]=1366x768

# CMO_M220Z1_L03_1680X1050
panel_name[24]=CMO_M220Z1_L03_1680X1050
panel_n_UP[24]=CMO_M220Z1_L03_1680X1050
resolution[24]=1680x1050

# LP154WX4_TLB4_1280X800
panel_name[25]=LP154WX4_TLB4_1280X800
panel_n_UP[25]=LP154WX4_TLB4_1280X800
resolution[25]=1280x800

# LTM170W1_L02_1280X768
panel_name[26]=LTM170W1_L02_1280X768
panel_n_UP[26]=LTM170W1_L02_1280X768
resolution[26]=1280x768

# LTN170WU_L02_1920X1200
panel_name[27]=LTN170WU_L02_1920X1200
panel_n_UP[27]=LTN170WU_L02_1920X1200
resolution[27]=1920x1200

# SAM20_LTM200KT10_1600X900
panel_name[28]=SAM20_LTM200KT10_1600X900
panel_n_UP[28]=SAM20_LTM200KT10_1600X900
resolution[28]=1600x900

# 05_GENERAL_1440X900
panel_name[29]=05_GENERAL_1440X900
panel_n_UP[29]=05_GENERAL_1440X900
resolution[29]=1440x900

#=======================================================
echo "===================================================="
echo "Start build YDG SOFTWARE "

function error_exit {
  echo "$1" 1>&2
  exit 1
}
#===================================================

iBuildIndex=0
iBuildIndex1=0
iBuildIndex2=0

#首先查找屏参分辨率中有无1440X900，有的话提醒放在最后一个编译，没有就不管

while [ "$iBuildIndex1" != "$iConfigNumber" ]
do	
    Res=${resolution[$iBuildIndex1]}
    icc=$(($iConfigNumber-1))
    if [ "$Res"x = "1440x900"x ]
    then
        if [ "$iBuildIndex1" != "$icc" ]
        then
        error_exit "1440x900应该放在最后一个编译 "
        fi
    fi
    iBuildIndex1=$(($iBuildIndex1+1))
done

echo "===================================================="
echo "Start build YDG SOFTWARE "
#需要改六 *
#需要改的地方是里面的JEDIA,MIRROR_JEDIA,MIRROR_VESA,VESA
#比如正常文件夹名为CSTM_KL_ENG_T_R5L_03C_05_GENERAL_1440x900_IRCVT00BF_KPD_LUCKY_JEDIA_20190417
#则要改成	JEDIA="CSTM_KL_ENG_T_R5L_03C_"$Panel_name"_IRCVT00BF_KPD_LUCKY_JEDIA_20190417"，其余三个类似

#第一步建立生成目录

rm -v -rf ${OUT_BIN_PATH}
mkdir -v ${OUT_BIN_PATH}
while ["$iBuildIndex2" != "$iConfigNumber"]
do
   Panel_name =${ panel_name[$iBuildIndex2]}
   OutBinPath =${ OUT_BIN_PATH}/$Panel_name
   JEDIA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_JEDIA_20190813"
   MIRROR_JEDIA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_MIRROR_JEDIA_20190813"
   MIRROR_VESA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_MIRROR_VESA_20190813"
   VESA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_VESA_20190813"

   mkdir - v $OutBinPath
   mkdir - v $OutBinPath /$JEDIA
   mkdir - v $OutBinPath /$MIRROR_JEDIA
   mkdir - v $OutBinPath /$MIRROR_VESA
   mkdir - v $OutBinPath /$VESA
   iBuildIndex2 =$(($iBuildIndex2 + 1))
done
chmod -R 777 ${OUT_BIN_PATH}

while ["$iBuildIndex" != "$iConfigNumber"]
do
    echo "-----------------------------------------"
    echo "[iBuildIndex=$iBuildIndex]"

    #第二步，查看customer是4:3还是16:9,
    # -lt:<      -gt:>       -ge:>=      -le:<=     -eq :==
    cd ~/$WORK_PATH / aps / customer / s2tek / sub_customer / s2tek / s2tek
    pwd

    if [ $iBuildIndex - eq $i4_3Index]
    then
        sed - i "s!$C4_3COSTOMER_OPEN!$C4_3COSTOMER_CLOSE!g" customize.h
        sed - i "s!$C16_9COSTOMER_CLOSE!$C16_9COSTOMER_OPEN!g" customize.h
     fi
    #第三步修改mconfig.config	
    Panel_name =${ panel_name[$iBuildIndex]}
    Panel_name_1 =${ panel_name[$iBuildIndex - 1]}
    Panel_n_UP=${panel_n_UP[$iBuildIndex]}
    Panel_n_UP_1=${panel_n_UP[$iBuildIndex-1]}
    Resolution =${ resolution[$iBuildIndex]}
    Resolution_1 =${ resolution[$iBuildIndex - 1]}
    OutBinPath =${ OUT_BIN_PATH}/$Panel_name
    cd ~/$WORK_PATH /
    pwd

   if [ $iBuildIndex - gt 0] 
    then
        echo "修改mconfig.config"
        #echo "[Panel_name=$Panel_name]"
        #echo "[Panel_name_1=$Panel_name_1]"
        sed - i "s/$Panel_name_1/$Panel_name/g" mconfig.config
        sed -i "s/$Panel_n_UP_1/$Panel_n_UP/g" mconfig.config
        sed - i "s/$Resolution_1/$Resolution/g" mconfig.config
    fi
    #第四步确定屏参,按照如下顺序编写正屏_JEIDA,倒屏_JEDIA,倒屏_VESA,正屏_VESA
    #并且要把编好的软件放到对应的文件夹
    # Get panel name

    echo "Panel_name=$Panel_name"
    iIndex = 0
    PANEL_INVERT_0 = "#define	PANEL_INVERT	0"
    PANEL_INVERT_1 = "#define	PANEL_INVERT	1"
    PANEL_LVDS_TYPE_0 = "#define	PANEL_LVDS_TYPE	 0"
    PANEL_LVDS_TYPE_2 = "#define	PANEL_LVDS_TYPE	 2"
#需要改七*
#可以直接复制‘需要改六’的JEIDA...   此处的作用的把编好的软件放到对应文件夹
   JEDIA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_JEDIA_20190813"
   MIRROR_JEDIA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_MIRROR_JEDIA_20190813"
   MIRROR_VESA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_MIRROR_VESA_20190813"
   VESA = "CSTM_YSK_FRE_T_R5L_A81_"$Panel_name"_IRCVT00BF_KPD_LUCKY_VESA_20190813"
   while [ $iIndex - le 4]
   do
       cd ~/$WORK_PATH / aps / customer / s2tek /public/panel/${Panel_name}
       pwd

   case ${iIndex} in
       0)
           echo 'This is 正屏_JEDIA'
           sed -i "/PANEL_INVERT/c$PANEL_INVERT_0"  panel_setting.h
           sed -i "/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_0"  panel_setting.h
           cd ~/$WORK_PATH
           make clean ; make -j
           cp -v./mergedir/$OUT_BIN_NAME  $OutBinPath/$JEDIA/  || error_exit "cannot copy *.bin file to directory"
       ;;
       1)
           echo 'This is 倒屏_JEDIA'
           sed -i "/PANEL_INVERT/c$PANEL_INVERT_1" panel_setting.h
           sed -i "/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_0" panel_setting.h
           cd ~/$WORK_PATH
           make -j
           cp -v./mergedir/$OUT_BIN_NAME  $OutBinPath/$MIRROR_JEDIA/ || error_exit "cannot copy *.bin file to directory"
       ;;
       2)
           echo 'This is 倒屏_VESA'
           sed -i "/PANEL_INVERT/c$PANEL_INVERT_1" panel_setting.h
           sed -i "/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_2" panel_setting.h
           cd ~/$WORK_PATH
           make -j
           cp -v./mergedir/$OUT_BIN_NAME  $OutBinPath/$MIRROR_VESA/ || error_exit "cannot copy *.bin file to directory"
       ;;
       3)
           echo 'This is 正屏_VESA'
           sed -i "/PANEL_INVERT/c$PANEL_INVERT_0" panel_setting.h
           sed -i "/PANEL_LVDS_TYPE/c$PANEL_LVDS_TYPE_2" panel_setting.h
           cd ~/$WORK_PATH
           make -j
           cp -v./mergedir/$OUT_BIN_NAME  $OutBinPath/$VESA/ || error_exit "cannot copy *.bin file to directory"
       ;;
       *)
           echo '编译完成'
       ;;
   esac
   iIndex =$(($iIndex+1))
   done

   iBuildIndex =$(($iBuildIndex+1))
done

#cd configs/melody
