program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;
begin
  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');
  Result := Ord(value[index + 1]);
end;

function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: Byte;
  v2: Boolean;
begin
  v0 := 'qwe';
  v1 := SpiralStringIndex(v0, 1);
  v2 := (v1 = 119);
  if v2 then begin
    Exit(0);
  end else begin
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
