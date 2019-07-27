<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.2" tiledversion="1.2.3" name="TileSet" tilewidth="16" tileheight="16" tilecount="20" columns="5">
 <image source="TileSet.png" width="80" height="64"/>
 <tile id="0" type="Dirt">
  <properties>
   <property name="TravelSpeed" type="float" value="1"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="1" type="Sand">
  <properties>
   <property name="TravelSpeed" type="float" value="0.8"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="2" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="1"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="3" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="1"/>
  </properties>
  <objectgroup draworder="index">
   <object id="3" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="4" type="Rock">
  <properties>
   <property name="TravelSpeed" type="float" value="0"/>
  </properties>
  <objectgroup draworder="index">
   <object id="2" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="5" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="0.5"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="6" type="Hulk">
  <properties>
   <property name="TravelSpeed" type="float" value="1"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="7" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="1"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="8" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="1"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="9" type="Dock">
  <objectgroup draworder="index">
   <object id="1" type="Dock" x="0" y="0" width="16" height="16">
    <properties>
     <property name="IslandID" type="int" value="0"/>
    </properties>
   </object>
  </objectgroup>
 </tile>
 <tile id="10" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="0.8"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="11" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="0.8"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="12" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="0.8"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="13" type="Water">
  <properties>
   <property name="TravelSpeed" type="float" value="0.8"/>
  </properties>
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="16"/>
  </objectgroup>
 </tile>
 <tile id="14" type="Dock"/>
</tileset>
