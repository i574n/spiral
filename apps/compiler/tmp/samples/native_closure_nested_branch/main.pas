program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TClosure0 = class(TFun0) v0: AnsiString; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
  TClosure1 = class(TFun0) v0: AnsiString; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
function ClosureCreate0(v0: AnsiString; v1: LongInt): TFun0; forward;
function ClosureCreate1(v0: AnsiString; v1: LongInt): TFun0; forward;
function method0(v0: TFun0): LongInt; forward;
function TClosure0.Invoke(v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v3 := v2 > 0;
  if v3 then begin
      v4 := LongInt(Length(v0));
      v5 := v4 + v1;
      v6 := v5 + v2;
      Result := v6;
  end else begin
      Result := 0;
  end;
end;
function ClosureCreate0(v0: AnsiString; v1: LongInt): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function TClosure1.Invoke(v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  v3 := v2 > 0;
  if v3 then begin
      v4 := LongInt(Length(v0));
      v5 := v4 + v1;
      v6 := v5 + v2;
      v7 := v6 - 1;
      Result := v7;
  end else begin
      Result := (-1);
  end;
end;
function ClosureCreate1(v0: AnsiString; v1: LongInt): TFun0;
var c: TClosure1;
begin
  c := TClosure1.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function method0(v0: TFun0): LongInt;
begin
  Result := v0.Invoke(37);
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
  v7: TFun0;
begin
  v0 := 'abc';
  v1 := 'wxyz';
  v2 := 2;
  v3 := 2;
  v4 := True;
  if v4 then begin
      v7 := ClosureCreate0(v0, v2);
  end else begin
      v7 := ClosureCreate1(v1, v3);
  end;
  Result := method0(v7);
end;
begin
  Halt(SpiralMain);
end.
