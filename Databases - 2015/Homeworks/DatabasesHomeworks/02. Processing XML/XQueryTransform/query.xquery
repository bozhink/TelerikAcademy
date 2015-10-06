<html xml:lang="en" xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" /> 
    <style type="text/css">
      body{{font-family: Verdana, Arial, Helvetica, sans-serif}}
      table, th, td{{border: 1px solid gray; border-collapse:collapse}}
      .alt1{{background-color:mistyrose}}
      .alt2{{background-color:azure}}
      .th{{background-color:silver}}
    </style>
    <title>Using XQuery</title>
  </head>
  <body>
    <h1>Using XQuery</h1>

    {
        for $album in catalog/album
        return 
        <article>
          <h3>{data($album/name)}</h3>
          {
            for $node in $album/node()[local-name(.)!='name' and local-name(.)!='songs'] return
            <div class="{name($node)}">{data($node)}</div>
          }
          <table>
            <tbody>
              {
                for $song in $album//song return
                <tr>
                  <td>{data($song/title)}</td>
                  <td>{data($song/duration)}</td>
                </tr>
              }
            </tbody>
          </table>
        </article>
    }
  </body>
</html>