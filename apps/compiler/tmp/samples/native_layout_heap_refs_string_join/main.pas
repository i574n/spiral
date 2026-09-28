program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralHeapRefs = class
  public
    name: UnicodeString;
    q: LongInt;
    w: LongInt;
    constructor Create;
    destructor Destroy; override;
  end;

constructor TSpiralHeapRefs.Create;
begin
  inherited Create;
  name := 'seed';
  q := 11;
  w := 13;
end;

destructor TSpiralHeapRefs.Destroy;
begin
  name := '';
  inherited Destroy;
end;

procedure SpiralAssignString(var target: UnicodeString; const value: UnicodeString);
var
  nextValue: UnicodeString;
begin
  nextValue := value;
  target := nextValue;
end;

function SpiralMain: LongInt;
var
  a, b: TSpiralHeapRefs;
begin
  a := TSpiralHeapRefs.Create;
  try
    if a.name = 'seed' then begin
      SpiralAssignString(a.name, 'grown');
      a.q := 19;
    end else begin
      SpiralAssignString(a.name, 'wrong');
      a.q := 29;
    end;
    b := a;
    if b.name = 'grown' then begin
      b.w := 23;
    end else begin
      b.w := 31;
    end;
    Result := LongInt(a.q + b.w);
  finally
    a.Free;
  end;
end;

begin
  Halt(SpiralMain);
end.
