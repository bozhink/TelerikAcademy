<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="no" omit-xml-declaration="yes" encoding="utf-8"/>
  <xsl:preserve-space elements="*"/>

  <xsl:template match="/">
    <html>
      <head>
        <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
        <title>Catalog</title>
      </head>
      <body>
        <xsl:apply-templates/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="catalog">
    <xsl:apply-templates/>
  </xsl:template>

  <xsl:template match="album">
    <article>
      <xsl:apply-templates/>
    </article>
  </xsl:template>

  <xsl:template match="album/name">
    <h3>
      <xsl:apply-templates/>
    </h3>
  </xsl:template>

  <xsl:template match="artist">
    <div class="artist">
      <xsl:apply-templates/>
    </div>
  </xsl:template>

  <xsl:template match="year">
    <div class="year">
      <xsl:apply-templates/>
    </div>
  </xsl:template>

  <xsl:template match="producer">
    <div class="producer">
      <xsl:apply-templates/>
    </div>
  </xsl:template>

  <xsl:template match="price">
    <div class="price">
      <xsl:apply-templates/>
    </div>
  </xsl:template>

  <xsl:template match="songs">
    <table>
      <tbody>
        <xsl:apply-templates/>
      </tbody>
    </table>
  </xsl:template>

  <xsl:template match="song">
    <tr>
      <xsl:apply-templates/>
    </tr>
  </xsl:template>

  <xsl:template match="title">
    <td>
      <xsl:apply-templates/>
    </td>
  </xsl:template>

  <xsl:template match="duration">
    <td>
      <xsl:apply-templates/>
    </td>
  </xsl:template>

  <xsl:template match="text()">
    <xsl:value-of select="."/>
  </xsl:template>

  <xsl:template match="@* | *"/>
</xsl:stylesheet>
