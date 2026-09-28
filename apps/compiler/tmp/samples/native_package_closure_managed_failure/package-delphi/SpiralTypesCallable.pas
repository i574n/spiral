unit SpiralTypesCallable;
{$mode objfpc}{$H+}

interface

type
  ClosureValue0 = record
    v0: AnsiString;
    variant: LongInt;
  end;

function ClosureValueCreate0(v0: AnsiString; variant: LongInt): ClosureValue0;
function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;

implementation

uses SysUtils;

function ClosureValueCreate0(v0: AnsiString; variant: LongInt): ClosureValue0;
begin
  Result.v0 := v0;
  Result.variant := variant;
end;

function ClosureInvoke0(x: ClosureValue0; v1: LongInt): LongInt;
begin
  if (x.variant = 0) then begin
    if (v1 = 0) then begin
      raise Exception.Create('package-owned managed closure zero argument');
    end;
    raise Exception.Create('package-owned managed closure failure');
  end else begin
    if (v1 = 0) then begin
      raise Exception.Create('package-owned managed closure alternate zero argument');
    end;
    raise Exception.Create('package-owned managed closure failure');
  end;
end;

end.
