defmodule Xsim.XCompat do
  alias Spiral.Kino.XCompat, as: Shared
  alias Xsim.Frames

  def check(source, opts \\ []) do
    id = Keyword.get(opts, :id, "x")
    Shared.rewrites(source) ++ over_limit(id, source)
  end

  defdelegate x_weight(text), to: Shared
  defdelegate segments(text), to: Shared
  defdelegate shortened_url_weight(), to: Shared
  defdelegate autolinks(text), to: Shared
  defdelegate format(path, finding), to: Shared

  defp over_limit(id, source) do
    for {k, n, _} = frame <- Frames.split(id, source),
        weight = x_weight(Frames.frame_text(id, frame)),
        weight > 280 do
      %{kind: :over_limit, line: nil, column: nil, text: "post #{k}/#{n} weighs #{weight}", hint: "autolinks count #{shortened_url_weight()} each once posted"}
    end
  end
end