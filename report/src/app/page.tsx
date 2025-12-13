import datas from "./merged.json"

interface DataItem {
  id: string
  original: {
    ot: string | null
    kw: Array<string | null>
  } | null
  gpt5: {
    nt: string | null
    kw: Array<string | null>
  } | null
  gpt51: {
    nt: string | null
    kw: Array<string | null>
  } | null
}

const dataItems: DataItem[] = [...datas]

export default function Page() {
  return (
    <section className="section" dir="rtl" lang="fa">
      <div className="container">
        <h1 className="title has-text-centered">مقایسه مدل‌های GPT</h1>

        <table className="table is-bordered is-striped is-fullwidth">
          <thead>
            <tr>
              <th>متن اصلی</th>
              <th>GPT-5</th>
              <th>GPT-5.1</th>
            </tr>
          </thead>
          <tbody>
            {dataItems.map(item => (
              <tr key={item.id}>
                <td>
                  {item?.original?.ot}
                  {item?.original?.kw?.length > 0 && (
                    <div style={{ fontSize: "0.8em", color: "#888", marginTop: "4px" }}>
                      {item.original.kw.filter(Boolean).join("، ")}
                    </div>
                  )}
                </td>
                <td>
                  {item?.gpt5?.nt}
                  {item?.gpt5?.kw?.length > 0 && (
                    <div style={{ fontSize: "0.8em", color: "#888", marginTop: "4px" }}>
                      {item.gpt5.kw.filter(Boolean).join("، ")}
                    </div>
                  )}
                </td>
                <td>
                  {item?.gpt51?.nt}
                  {item?.gpt51?.kw?.length > 0 && (
                    <div style={{ fontSize: "0.8em", color: "#888", marginTop: "4px" }}>
                      {item.gpt51.kw.filter(Boolean).join("، ")}
                    </div>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </section>
  )
}
