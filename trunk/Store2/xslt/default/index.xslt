<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" 
xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
xpath-default-namespace="http://docbook.org/ns/docbook">

	<xsl:template match="info">
		<xsl:value-of select="title" />
	</xsl:template>		
	
	<xsl:template match="mediaobject">
			<xsl:for-each select="imageobject/imagedata">
				<xsl:element name="img">
					<xsl:attribute name="src"><xsl:value-of select="attribute::fileref"/></xsl:attribute>	
				</xsl:element>
			</xsl:for-each>
	</xsl:template>	
	
	<xsl:output method="html" encoding="utf-16"/>
	<xsl:template match="/">
		<xsl:apply-templates select="/book/info" />
		<xsl:apply-templates select="/book/mediaobject" />
	</xsl:template>
</xsl:stylesheet>
