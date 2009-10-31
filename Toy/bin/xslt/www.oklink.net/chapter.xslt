<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns="http://docbook.org/ns/docbook" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xi="http://www.w3.org/2001/XInclude" xpath-default-namespace="http://www.w3.org/1999/xhtml">
	<xsl:output method="xml" version="1.0" encoding="UTF-16" indent="yes"/>
	<xsl:template match="/">
		<chapter version="5.0">
			<title><xsl:value-of select="html/body/center/b/font/font/font" /></title>
			<xsl:analyze-string select="html/body/div/table/tr/td/pre/span/text()[1]" regex="\s+([\S*\n]+)">
				<xsl:matching-substring>
					<para><xsl:value-of select="replace(regex-group(1), '\n', '')"/></para>
				</xsl:matching-substring>
			</xsl:analyze-string>
		</chapter>
	</xsl:template>
	
</xsl:stylesheet>
