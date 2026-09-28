program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralIntArray = array of LongInt;
  TSpiralHeapRefs = class
  public
    items: TSpiralIntArray;
    q: LongInt;
    w: LongInt;
    constructor Create;
    destructor Destroy; override;
  end;

constructor TSpiralHeapRefs.Create;
begin
  inherited Create;
  items := [1, 2];
  q := 0;
  w := 0;
end;

destructor TSpiralHeapRefs.Destroy;
begin
  SetLength(items, 0);
  inherited Destroy;
end;

procedure SpiralAssignIntArray(var target: TSpiralIntArray; const value: TSpiralIntArray);
var
  nextValue: TSpiralIntArray;
begin
  nextValue := Copy(value, 0, Length(value));
  target := nextValue;
end;

function SpiralMain: LongInt;
var
  a, b: TSpiralHeapRefs;
  next_items_length: LongInt;
begin
  a := TSpiralHeapRefs.Create;
  try
    b := a;
    if a.q = 0 then begin
      SpiralAssignIntArray(a.items, [19, 23]);
      next_items_length := Length(b.items);
      SetLength(b.items, 3);
      while next_items_length < 3 do begin
        b.items[next_items_length] := 23;
        Inc(next_items_length);
      end;
    end else begin
      SpiralAssignIntArray(a.items, [31]);
      next_items_length := Length(b.items);
      SetLength(b.items, 2);
      while next_items_length < 2 do begin
        b.items[next_items_length] := 11;
        Inc(next_items_length);
      end;
    end;
    a.items[1] := 17;
    a.q := b.items[0];
    a.w := a.items[2];
    Result := LongInt(a.q + a.w);
  finally
    a.Free;
  end;
end;

begin
  Halt(SpiralMain);
end.
