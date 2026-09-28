program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

function SpiralStringIndex(const value: AnsiString; index: LongInt): Byte;
begin
  if (index < 0) or (index >= Length(value)) then raise ERangeError.Create('Spiral string index out of bounds');
  Result := Ord(value[index + 1]);
end;

function SpiralStringConcat(const left, right: AnsiString): AnsiString;
begin
  Result := left + right;
end;

function choose_left0(v0: Boolean): AnsiString;
var
  v1: AnsiString;
  v2: AnsiString;
begin
  if v0 then begin
    v1 := 'spi';
    Exit(v1);
  end else begin
    v2 := 'bad';
    Exit(v2);
  end;
end;

function choose_right1(v0: Boolean): AnsiString;
var
  v1: AnsiString;
  v2: AnsiString;
begin
  if v0 then begin
    v1 := 'bad';
    Exit(v1);
  end else begin
    v2 := 'ral';
    Exit(v2);
  end;
end;

function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: AnsiString;
  v2: Boolean;
  v3: AnsiString;
  v4: AnsiString;
  v5: LongInt;
  v6: Boolean;
  v7: Byte;
  v8: Boolean;
  v9: Byte;
  v10: Boolean;
begin
  v0 := True;
  v1 := choose_left0(v0);
  v2 := False;
  v3 := choose_right1(v2);
  v4 := SpiralStringConcat(v1, v3);
  v5 := Length(v4);
  v6 := (v5 = 6);
  if v6 then begin
    v7 := SpiralStringIndex(v4, 0);
    v8 := (v7 = 115);
    if v8 then begin
      v9 := SpiralStringIndex(v4, 5);
      v10 := (v9 = 108);
      if v10 then begin
        Exit(0);
      end else begin
        Exit(1);
      end;
    end else begin
      Exit(2);
    end;
  end else begin
    Exit(3);
  end;
end;

begin
  Halt(SpiralMain);
end.
