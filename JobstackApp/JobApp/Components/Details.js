import { StyleSheet, Text, View,ScrollView ,StatusBar} from 'react-native'
import { AntDesign } from '@expo/vector-icons';
import { EvilIcons } from '@expo/vector-icons';
import { FontAwesome } from '@expo/vector-icons';
import React from 'react'

const Details = ({navigation}) => {
  return (
    <ScrollView>
      <View style={styles.container}>
        <StatusBar backgroundColor={'#059669'} style="light"/>
        <Text style={styles.leftControl} onPress={()=>navigation.navigate('Home')}><AntDesign name="left" size={24} color="white" /></Text>
        <Text style={styles.textCenter} >Details</Text>
      </View>
      <View style={styles.mainDetail}>
        <View style={styles.titleInfos}>
          <Text style={styles.vacancyName}>Back-End Developer</Text>  
          <View style={styles.otherInfos}>
              <Text><FontAwesome name="building-o" size={24} color="#129b71" />Lenovo LTD.</Text>
              <Text><EvilIcons name="location" size={24} color="#129b71" />Baku,Azerbaijan</Text>
          </View>
        </View>
        {/* <View style={styles.titleInfos}>
          <Text style={styles.vacancyName}>Back-End Developer</Text>  
        </View> */}
      </View>
    </ScrollView>
  )
}

export default Details;

const styles = StyleSheet.create({
  container: {
    display:'flex',
   // flexDirection:'row',
    justifyContent:'center',
    alignItems:'center',
    // paddingTop:5,
    width:400,
    height:90,
    backgroundColor:'#059669',
  },
  textCenter:{
     color:'white',
     fontSize:23,
     fontWeight:'bold',
  },
  leftControl:{
    paddingRight:340,
    position:'absolute',
    top:35
  },
  mainDetail:{
    display:'flex',
    flexDirection:'column',
    gap:12,
    marginLeft:3,
    marginTop:5,
    width:385,
   // height:'auto',
    height:1000,
    backgroundColor:'red'
  },
  titleInfos:{
     width:370,
     height:160,
     backgroundColor:'cyan',
     marginLeft:8,
     borderRadius:7,
     display:'flex',
     flexDirection:'column'
  },
  vacancyName:{
     width:'auto',
     height:70,
     fontSize:23,
     fontWeight:'bold',
     backgroundColor:'yellow',
     paddingTop:18,
     paddingLeft:12
  },
  otherInfos:{
    width:'auto',
    height:90,
    backgroundColor:'#a8329b'
  }
})