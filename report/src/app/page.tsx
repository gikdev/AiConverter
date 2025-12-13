import datas from "./merged.json"

interface DataItem {
  id: string
  original: {
    ot: string | null
    kw: Array<string | null>
  } | null
  oldOne: {
    nt: string | null
    kw: Array<string | null>
  } | null
  newOne: {
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
              <th>قدیمی</th>
              <th>جدید</th>
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
                  {item?.oldOne?.nt}
                  {item?.oldOne?.kw?.length > 0 && (
                    <div style={{ fontSize: "0.8em", color: "#888", marginTop: "4px" }}>
                      {item.oldOne.kw.filter(Boolean).join("، ")}
                    </div>
                  )}
                </td>
                <td>
                  {item?.newOne?.nt}
                  {item?.newOne?.kw?.length > 0 && (
                    <div style={{ fontSize: "0.8em", color: "#888", marginTop: "4px" }}>
                      {item.newOne.kw.filter(Boolean).join("، ")}
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
