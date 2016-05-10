<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:student="urn:students" xmlns:exam="urn:exams">
  <xsl:output method="html" indent="yes" encoding="utf-8" omit-xml-declaration="yes" version="5.0"/>

  <xsl:preserve-space elements="*"/>

  <xsl:template match="/">
    <html lang="en" xmlns="http://www.w3.org/1999/xhtml">
      <head>
        <meta charset="utf-8" />
        <title>Students list</title>
        <link href="../content/bootstrap.min.css" rel="stylesheet" />
        <link href="custom-style.css" rel="stylesheet" />
      </head>
      <body>
        <h1>Students</h1>
        <xsl:apply-templates select="//student:student"/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="student:student">
    <article>
      <xsl:apply-templates/>
    </article>
  </xsl:template>

  <xsl:template match="student:name">
    <h3 xmlns="http://www.w3.org/1999/xhtml">
      <xsl:value-of select="normalize-space(.)"/>
    </h3>
  </xsl:template>

  <xsl:template match="student:*">
    <div class="student-detail">
      <strong>
        <xsl:value-of select="local-name(.)"/>
        <xsl:text>: </xsl:text>
      </strong>
      <xsl:apply-templates/>
    </div>
  </xsl:template>

  <xsl:template match="student:taken-exams">
    <table>
      <caption>
        <xsl:value-of select="local-name(.)"/>
      </caption>
      <thead>
        <tr>
          <th>Course name</th>
          <th>Tutor</th>
          <th>Score</th>
        </tr>
      </thead>
      <tbody>
        <xsl:apply-templates/>
      </tbody>
    </table>
  </xsl:template>

  <xsl:template match="exam:*">
    <tr>
      <xsl:apply-templates select="@exam:name"/>
      <xsl:apply-templates select="@exam:tutor"/>
      <xsl:apply-templates select="@exam:score"/>
    </tr>
  </xsl:template>

  <xsl:template match="@exam:*">
    <td>
      <xsl:value-of select="."/>
    </td>
  </xsl:template>
</xsl:stylesheet>
