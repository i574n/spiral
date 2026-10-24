defmodule Spiral.Cells.Tables do
  @spec ensure(atom(), list()) :: atom()
  def ensure(name, options) do
    case :ets.whereis(name) do
      :undefined -> create(name, options)
      _ -> name
    end
  end

  defp create(name, options) do
    caller = self()
    reply = make_ref()

    spawn(fn ->
      created =
        try do
          :ets.new(name, [:named_table, :public | options])
          true
        rescue
          ArgumentError -> false
        end

      send(caller, {reply, name})
      if created, do: Process.sleep(:infinity)
    end)

    receive do
      {^reply, ^name} -> name
    after
      5_000 -> name
    end
  end
end