<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns="http://docbook.org/ns/docbook" 
							xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
							xmlns:fn="http://www.w3.org/2005/xpath-functions" 
							xmlns:xi="http://www.w3.org/2001/XInclude" 
							xpath-default-namespace="http://www.w3.org/1999/xhtml">
	<xsl:output method="xml" version="1.0" encoding="UTF-16" indent="yes"/>
	<xsl:template match="/">
		<book version="5.0">
			<info>
				<title>
					<xsl:value-of select="html/head/title"/>
				</title>
				<author>
					<personname>
						<othername><xsl:value-of select="html/body/div/table/tr/td/div/text()"/></othername>
					</personname>
				</author>
				<bibliosource>http://jeebook.com/blog/?p=513</bibliosource>
			</info>
			<xsl:for-each select="html/body/div/table//a">
					<xsl:variable name="href" select="@href" />
					<xsl:choose>
						<xsl:when test="ends-with($href, '.zip')" />
						<xsl:otherwise>
							<xsl:element name="xi:include">
								 <xsl:attribute name="href"><xsl:value-of select="@href" /></xsl:attribute>
								  <xsl:value-of select="text()"/>
							</xsl:element>						
						</xsl:otherwise>
					</xsl:choose>
			</xsl:for-each>
		</book>
	</xsl:template>
</xsl:stylesheet>
